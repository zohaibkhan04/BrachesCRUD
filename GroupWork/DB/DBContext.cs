using System.Collections.Generic;

namespace GroupWork.DB
{
    public class DBContext
    {
        public DbSet<CompanyBranch> CompanyBranches { get; set; }

       

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }
    }
}
