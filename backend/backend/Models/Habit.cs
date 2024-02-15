using backend.Enums;
using DayOfWeek = System.DayOfWeek;

namespace backend.Models;

public class Habit
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; }
    public TimeOfDay DayTime { get; set; }
    public IList<DayOfWeek> DaysOfWeek { get; set; }
}