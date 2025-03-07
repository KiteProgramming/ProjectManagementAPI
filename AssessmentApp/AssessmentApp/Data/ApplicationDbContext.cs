using Microsoft.EntityFrameworkCore;
using AssessmentApp.Models;

namespace AssessmentApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Assessment> Assessments { get; set; }
    }
}