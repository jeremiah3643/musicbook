using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicBook.Models;

namespace MusicBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageBox> MessageBoxes { get; set; }
        public DbSet<PlayerInstrument> PlayerInstruments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PlayerInstrument>().ToTable("PlayerInstrument");

            modelBuilder.Entity<PlayerInstrument>()
                    .HasKey(p => new
                    {
                        p.ApplicationUserId,
                        p.InstrumentId
                    });
        }
    }
}
