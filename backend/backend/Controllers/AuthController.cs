using backend.Data;
using backend.Models;
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

    [HttpPost]
    public JsonResult Login(User user)
    {
        var foundUser = _context.Users.Find(user.Id);

        if (foundUser == null)
            return new JsonResult("User not found") { StatusCode = 404 };

        if (foundUser.Password != user.Password)
            return new JsonResult("Invalid password") { StatusCode = 400 };

        // todo: implement JWT token generation

        return new JsonResult(foundUser);
    }

    [HttpPost]
    public JsonResult Register(User user)
    {
        var userExists = _context.Users.Find(user.Email);

        if (userExists != null)
            return new JsonResult("User with that email already exists") { StatusCode = 400 };

        // todo: implement hashing of password

        _context.Users.Add(user);

        return new JsonResult("Successfully registered user");
    }

    [HttpDelete]
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