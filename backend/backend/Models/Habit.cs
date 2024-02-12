namespace backend.Models;

public enum DayOfWeek
{
    Sunday = 0,
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6
}

public class Habit
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; }
    public IList<DayOfWeek> DaysOfWeek { get; set; }
}