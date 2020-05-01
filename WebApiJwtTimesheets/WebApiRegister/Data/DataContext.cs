using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using WebApiRegister.Entities;

namespace WebApiRegister.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimesheetRow>()
                .HasOne(tsr => tsr.Timesheet)
                .WithMany(t => t.TimesheetRows)
                .HasForeignKey(t => t.TimesheetId);

            modelBuilder.Entity<TimesheetRow>()
               .HasOne(tsr => tsr.Project)
               .WithMany(p => p.TimesheetRows)
               .HasForeignKey(t => t.ProjectId);

            modelBuilder.Entity<TimesheetRow>()
                .HasOne(tsr => tsr.Task)
                .WithMany(p => p.TimesheetRows)
                .HasForeignKey(t => t.TaskId);

            modelBuilder.Entity<Timesheet>()
                 .HasOne(t => t.User)
                .WithMany(u => u.Timesheets)
                 .HasForeignKey(t => t.UserId);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; }


        public DbSet<WebApiRegister.Entities.Timesheet> Timesheet { get; set; }


        public DbSet<WebApiRegister.Entities.TimesheetRow> TimesheetRow { get; set; }
    }
}
