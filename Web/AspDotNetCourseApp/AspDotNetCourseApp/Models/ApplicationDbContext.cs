using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspDotNetCourseApp.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes{ get; set; }
        public DbSet<Genre> Genres { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}