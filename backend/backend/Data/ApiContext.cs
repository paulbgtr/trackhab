using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {
    }

    public DbSet<Habit> Habits { get; set; }
    public DbSet<User> Users { get; set; }
}