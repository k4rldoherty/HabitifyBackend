using HabitifyBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HabitifyBackend.Data
{
    // Generates couple of tables used in auth
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitLog> HabitLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Habit>()
                .HasOne(h => h.User)
                .WithMany(u => u.Habits)
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<HabitLog>()
                .HasOne(hl => hl.User)
                .WithMany(u => u.HabitLogs)
                .HasForeignKey(hl => hl.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<HabitLog>()
                .HasOne(hl => hl.Habit)
                .WithMany(h => h.HabitLogs)
                .HasForeignKey(hl => hl.HabitId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
