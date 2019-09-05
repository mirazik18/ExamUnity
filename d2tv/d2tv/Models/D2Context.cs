using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace d2tv.Models
{
    public class D2Context : IdentityDbContext<User>
    {
        public D2Context(DbContextOptions<D2Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


        public DbSet<News> News { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
