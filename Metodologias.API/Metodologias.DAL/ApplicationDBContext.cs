using Metodologias.Infrastracture.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Signal>(sinal =>
            {
                sinal.HasKey(t => t.Id);

            });

            builder.Entity<TemporalInformation>(ti =>
            {
                ti.HasKey(t => t.Id);

                ti.HasOne(t => t.Signal).WithMany(t => t.TemporalInformation).HasForeignKey(t => t.SignalId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Survey>(s =>
            {
                s.HasKey(t => t.Id);

                s.HasOne(t => t.TemporalInformation).WithMany(t => t.Surveys).HasForeignKey(t => t.TempotalInformationId).OnDelete(DeleteBehavior.Cascade);

                s.HasOne(t => t.Team).WithMany(t => t.Surveys).HasForeignKey(t => t.TeamId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Team>(ti =>
            {
                ti.HasKey(t => t.Id);
            });

            builder.Entity<Technician>(s =>
            {
                s.HasKey(t => t.Id);

                s.HasOne(t => t.Team).WithMany(t => t.Technicians).HasForeignKey(t => t.TeamId).OnDelete(DeleteBehavior.Cascade);
            });



        }
        public DbSet<Signal> Sinals { get; set; }
        public DbSet<TemporalInformation> TemporalInformation { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Technician> Technicians { get; set; }
    }
}
