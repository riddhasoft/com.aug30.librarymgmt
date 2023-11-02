using com.aug30.librarymgmt.Models;
using Microsoft.EntityFrameworkCore;

namespace com.aug30.librarymgmt.Data
{
    public class AppDbContext : DbContext
    {
        //DbContextOptions options will be initialized from application start (program.cs)
        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<EBookCategory> BookCategories { get; set; }
        public DbSet<EBookInformation> BookInformations { get; set; }
        public DbSet<EMemberInformation> MemberInformations { get; set; }
        public DbSet<EUserInformation> UserInformations { get; set; }
    }
}
