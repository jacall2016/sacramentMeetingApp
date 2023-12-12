using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sacramentMeetingApp.Models;

namespace sacramentMeetingApp.Data
{
    public class sacramentMeetingAppContext : DbContext
    {
        public sacramentMeetingAppContext(DbContextOptions<sacramentMeetingAppContext> options)
            : base(options)
        {
        }

        public DbSet<sacramentMeetingApp.Models.Member> Member { get; set; } = default!;
        public DbSet<sacramentMeetingApp.Models.SacramentProgram> SacramentProgram { get; set; } = default!;
        public DbSet<sacramentMeetingApp.Models.Unit> Unit { get; set; } = default!;
        public DbSet<sacramentMeetingApp.Models.Talk> Talk { get; set; }
        public DbSet<sacramentMeetingApp.Models.Hymn> Hymn { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Talk>()
                .HasOne(_ => _.SacramentProgram)
                .WithMany(a => a.Talk)
                .HasForeignKey(p => p.SacramentProgramId);
        }
    }
}
