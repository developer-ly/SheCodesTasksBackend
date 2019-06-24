using Microsoft.EntityFrameworkCore;
using shecodes.tasks.models;

namespace shecodes.tasks.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() {}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}