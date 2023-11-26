using Api1App.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api1App.Data
{
    public class StudenDbContext : DbContext
    {
        public StudenDbContext(DbContextOptions<StudenDbContext> options)
            :base(options) 
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
