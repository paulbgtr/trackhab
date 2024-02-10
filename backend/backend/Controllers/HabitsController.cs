using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HabitsController : ControllerBase
{
    private readonly ApiContext _context;

    public HabitsController(ApiContext context)
    {
        _context = context;
    }

    [HttpPost]
    public JsonResult CreateEdit(Habit habit)
    {
        if (habit.Id == 0)
        {
            _context.Habits.Add(habit);
        }
        else
        {
            var habitInDb = _context.Habits.Find(habit.Id);

            if (habitInDb == null) return new JsonResult("Habit not found") { StatusCode = 404 };

            habitInDb = habit;
        }

        _context.SaveChanges();

        return new JsonResult(habit) { StatusCode = 201 };
    }
}