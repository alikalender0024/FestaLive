using FestaLive.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.DataAccess.Concrete.Context
{
    public class FestaLiveContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FestaLiveDB;Integrated Security=True");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }

}
