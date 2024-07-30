using CampFes.Models.Login;
using CampFes.Models.Quest;
using CampFes.Models.Regis;
using CampFes.Models.System;
using Microsoft.EntityFrameworkCore;

namespace CampFes.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllowPlayer>(entity =>
            {
                entity.Property(e => e.IS_STAFF).HasDefaultValue("N");
                entity.HasNoKey();
            });

            modelBuilder.Entity<EasyUser>(entity =>
            {
                entity.Property(o => o.UID).ValueGeneratedNever();
            });

            modelBuilder.Entity<QuestHistory>(entity =>
            {
                entity.Property(e => e.START_TIME).HasDefaultValueSql("GETDATE()");
                entity.HasKey(o => new { o.UID, o.QNO });
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(o => o.QID).ValueGeneratedNever();
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.Property(e => e.IS_RECIEVED).HasDefaultValue("N");
                entity.Property(o => o.RID).ValueGeneratedNever();
            });

            modelBuilder.Entity<CheckPoint>(entity =>
            {
                entity.Property(o => o.CID).ValueGeneratedNever();
            });

            base.OnModelCreating(modelBuilder);
        }

        //Login
        public DbSet<AllowPlayer> AllowPlayer { get; set; }
        public DbSet<EasyUser> EasyUser { get; set; }
        public DbSet<Role> Role { get; set; }

        //Quest
        public DbSet<QuestHistory> QuestHistory { get; set; }
        public DbSet<Question> Question { get; set; }

        //Regis
        public DbSet<Registration> Registration { get; set; }

        //System
        public DbSet<ErrorLog> ErrorLog { get; set; }

        //Root
        public DbSet<CheckPoint> CheckPoint { get; set; }
    }
}
