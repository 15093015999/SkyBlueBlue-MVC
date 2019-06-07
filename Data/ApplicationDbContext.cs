using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkyBlueBlue.Models;

namespace SkyBlueBlue.Date
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<TopicModel> Topics { get; set; }
        public DbSet<PaperModel> Papers {get;set;}
        public DbSet<SuccessModel> Success {get;set;}
    }

}