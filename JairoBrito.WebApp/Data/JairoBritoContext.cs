using JairoBrito.WebApp.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JairoBrito.WebApp.Data;

public class JairoBritoContext : DbContext
{
    public JairoBritoContext(DbContextOptions<JairoBritoContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("communication");
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<MessageData> Messages { get; set; }
}