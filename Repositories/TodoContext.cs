using FireForgetEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace FireForgetEntityFramework.Repositories;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<TodoHistory> TodoHistories { get; set; }
}