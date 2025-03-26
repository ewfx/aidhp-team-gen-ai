using Hyper_Personalization.Models;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Personalization.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
