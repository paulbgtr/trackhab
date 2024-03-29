using backend.Data;
using backend.Models;
using backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class HabitsController : ControllerBase
{
    private readonly ApiContext _context;

    public HabitsController(ApiContext context)
    {
        _context = context;
    }


    [HttpGet("{habitId}")]
    public JsonResult Get(int habitId, int userId)
    {
        var foundHabit = _context.Habits
            .Where(hbt => hbt.Id == habitId && hbt.UserId == userId)
            .ToList();

        if (!foundHabit.Any())
            return new JsonResult($"Habit with and id of {habitId} is not found") { StatusCode = 404 };

        return new JsonResult(foundHabit);
    }

    [HttpPost]
    public JsonResult Create(Habit habit)
    {
        var token = Request.Headers.Authorization.ToString().Split(" ")[1];

        var userId = JwtUtils.ExtractUserIdFromToken(token);

        var habitExists = _context.Habits.Find(habit.Id);

        if (habitExists != null) return new JsonResult("Habit already exists") { StatusCode = 400 };

        habit.UserId = userId;

        _context.Habits.Add(habit);
        _context.SaveChanges();

        return new JsonResult(habit);
    }

    [HttpDelete("{habitId}")]
    public JsonResult Delete(int habitId)
    {
        var habitExists = _context.Habits.Find(habitId);

        if (habitExists == null)
            return new JsonResult($"Habit with and id of {habitId} is not found") { StatusCode = 404 };

        _context.Habits.Remove(habitExists);
        _context.SaveChanges();

        return new JsonResult($"Habit with and id of {habitId} has been deleted");
    }

    [HttpPut]
    public JsonResult Update(Habit habit)
    {
        var habitExists = _context.Habits.Find(habit.Id);

        if (habitExists == null)
            return new JsonResult($"Habit with and id of {habit.Id} is not found") { StatusCode = 404 };

        habitExists.Title = habit.Title;
        habitExists.IsDone = habit.IsDone;
        habitExists.DaysOfWeek = habit.DaysOfWeek;

        _context.SaveChanges();

        return new JsonResult(habitExists);
    }
}