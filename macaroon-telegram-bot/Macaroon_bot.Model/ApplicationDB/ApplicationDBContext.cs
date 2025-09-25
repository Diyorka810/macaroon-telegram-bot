using MacaroonBot.Model;
using Microsoft.EntityFrameworkCore;

namespace Macaroon_bot.Model
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        // Родители
        public DbSet<Parent> Parents { get; set; }
        // Дети
        public DbSet<Child> Children { get; set; }
        // Группы
        public DbSet<Group> Groups { get; set; }
        // Сотрудники
        public DbSet<Staff> Staff { get; set; }
        // Расписание
        public DbSet<Schedule> Schedules { get; set; }
        // Посещаемость
        public DbSet<Attendance> Attendances { get; set; }
        // Оплаты
        public DbSet<Payment> Payments { get; set; }
        // Уведомления / рассылки
        public DbSet<Notification> Notifications { get; set; }
        // Отчёты
        public DbSet<OwnerReport> OwnerReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Parent → Child (1 ко многим)
            modelBuilder.Entity<Child>()
                .HasOne(c => c.Parent)
                .WithMany(p => p.Children)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Child → Group (многие к одному)
            modelBuilder.Entity<Child>()
                .HasOne(c => c.Group)
                .WithMany(g => g.Children)
                .HasForeignKey(c => c.GroupId)
                .OnDelete(DeleteBehavior.SetNull);

            // Group → Staff (преподаватель)
            modelBuilder.Entity<Group>()
                .HasOne(g => g.Teacher)
                .WithMany(s => s.Groups)
                .HasForeignKey(g => g.TeacherId)
                .OnDelete(DeleteBehavior.SetNull);

            // Attendance → Child
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Child)
                .WithMany(c => c.Attendances)
                .HasForeignKey(a => a.ChildId)
                .OnDelete(DeleteBehavior.Cascade);

            // Attendance → Staff
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Staff)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StaffId)
                .OnDelete(DeleteBehavior.Cascade);

            // Payment → Parent + Child
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Parent)
                .WithMany(pr => pr.Payments)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Child)
                .WithMany()
                .HasForeignKey(p => p.ChildId)
                .OnDelete(DeleteBehavior.Cascade);

            // Notification → Staff
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.CreatedBy)
                .WithMany(s => s.Notifications)
                .HasForeignKey(n => n.CreatedById)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
