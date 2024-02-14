using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace backend.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly ApiContext _context;

    public AuthController(ApiContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    private string GenerateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpPost("login")]
    public JsonResult Login(User user)
    {
        var foundUser = _context.Users.FirstOrDefault(usr => usr.Email == user.Email);

        if (foundUser == null)
            return new JsonResult("User not found") { StatusCode = 404 };

        var hasher = new PasswordHasher<User>();
        var passwordVerification = hasher.VerifyHashedPassword(foundUser, foundUser.Password, user.Password);

        if (passwordVerification != PasswordVerificationResult.Success)
            return new JsonResult("Invalid Password") { StatusCode = 401 };

        var token = GenerateJwtToken(foundUser);

        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTimeOffset.Now.AddMinutes(120)
        };
        Response.Cookies.Append("jwt", token, cookieOptions);

        return new JsonResult(new { user = foundUser.Email });
    }

    [HttpPost("register")]
    public JsonResult Register(User user)
    {
        var userExists = _context.Users.FirstOrDefault(usr => usr.Email == user.Email);

        if (userExists != null)
            return new JsonResult("User with that email already exists") { StatusCode = 400 };

        var hasher = new PasswordHasher<User>();
        user.Password = hasher.HashPassword(user, user.Password);

        _context.Users.Add(user);
        _context.SaveChanges();

        return new JsonResult("Successfully registered user");
    }

    [HttpDelete("{userId}")]
    public JsonResult Delete(int userId)
    {
        var userExists = _context.Users.Find(userId);

        if (userExists == null)
            return new JsonResult($"User with an id of {userId} is not found") { StatusCode = 404 };

        _context.Users.Remove(userExists);
        _context.SaveChanges();

        return new JsonResult($"User with and id of {userId} has been deleted");
    }
}