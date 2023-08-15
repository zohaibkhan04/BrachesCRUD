using GroupWork.Models;
using Microsoft.EntityFrameworkCore;
namespace GroupWork.DB
{
  
   
    
    
        public class ApplicationDbContext : DbContext
        {
            public DbSet<BranchesModel> CompanyBranches { get; set; }

            // Add DbSet properties for other tables if needed

            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Configure entity mappings if needed
            }
        }
    }


