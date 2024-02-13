using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ApiContext _context;

    public AuthController(ApiContext context)
    {
        _context = context;
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

        // todo: implement JWT token generation

        return new JsonResult(foundUser);
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