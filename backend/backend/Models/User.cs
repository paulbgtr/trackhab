namespace backend.Models;

public class User
{
    public User()
    {
        CreatedAt = DateTime.Now;
    }

    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
}