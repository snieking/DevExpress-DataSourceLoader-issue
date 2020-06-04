using System;
using DevExpressGroupingExample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DevExpressGroupingExample.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<ActivityParticipant> ActivityParticipants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false)
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.Sk).HasColumnName("SK");
                entity.HasKey(e => e.Sk);
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.Property(e => e.Sk).HasColumnName("SK");
                entity.HasKey(e => e.Sk);
            });

            modelBuilder.Entity<ActivityParticipant>(entity =>
            {
                entity.Property(a => a.ParticipantSk).HasColumnName("ParticipantSK");
                entity.Property(a => a.ActivitySk).HasColumnName("ActivitySK");

                entity.HasKey(ar => new { ar.ActivitySk, ar.ParticipantSk });

                entity.HasOne(a => a.Activity)
                    .WithMany(a => a.ActivityParticipants)
                    .HasForeignKey(a => a.ActivitySk);
                entity.HasOne(p => p.Participant)
                    .WithMany(p => p.ActivityParticipants)
                    .HasForeignKey(p => p.ParticipantSk);
            });

            modelBuilder.Entity<ParticipantGroup>(entity =>
            {
                entity.Property(a => a.ParticipantSk).HasColumnName("ParticipantSK");
                entity.Property(a => a.GroupSk).HasColumnName("GroupSK");

                entity.HasKey(p => new { p.ParticipantSk, p.GroupSk });

                entity.HasOne(p => p.Participant);
            });

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var participant = new Participant { Sk = 1, FirstName = "Viktor", LastName = "Plane" };
            var activity = new Activity { Sk = 1, Name = "Football" };
            var activityParticipant = new ActivityParticipant
                { ActivitySk = activity.Sk, ParticipantSk = participant.Sk, ResultStatus = "Victory" };
            var participantGroup = new ParticipantGroup
            {
                GroupSk = 0,
                ParticipantSk = participant.Sk,
                GroupCategory = "Company",
                GroupName = "Simployer"
            };

            modelBuilder.Entity<Participant>().HasData(participant);
            modelBuilder.Entity<Activity>().HasData(activity);
            modelBuilder.Entity<ActivityParticipant>().HasData(activityParticipant);
            modelBuilder.Entity<ParticipantGroup>().HasData(participantGroup);
        }
    }
}