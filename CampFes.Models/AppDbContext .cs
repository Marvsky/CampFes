using CampFes.Models.Login;
using CampFes.Models.Lottery;
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
            //Nokey Table
            //[AllowPlayer] [QuestHistory]

            modelBuilder.Entity<AllowPlayer>(entity =>
            {
                entity.Property(e => e.IS_STAFF).HasDefaultValue("N");
                entity.HasNoKey();
            });

            modelBuilder.Entity<AllUsers>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<EasyUser>(entity =>
            {
                entity.Property(o => o.UID).ValueGeneratedNever();
                entity.Property(e => e.IS_LOGIN).HasDefaultValue("N");
                entity.Property(e => e.IS_RECIEVED).HasDefaultValue("N");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.HAS_PRIZE).HasDefaultValue("N");
            });

            modelBuilder.Entity<Prize>(entity =>
            {
                entity.Property(o => o.PID).ValueGeneratedNever();
            });

            modelBuilder.Entity<QuestHistory>(entity =>
            {
                //組合鍵
                entity.HasKey(o => new { o.UID, o.QNO });
                entity.Property(e => e.START_TIME).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(o => o.QID).ValueGeneratedNever();
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.Property(o => o.RID).ValueGeneratedNever();
                entity.Property(e => e.IS_RECIEVED).HasDefaultValue("N");
            });

            modelBuilder.Entity<CheckPoint>(entity =>
            {
                entity.Property(o => o.CID).ValueGeneratedNever();
            });

            base.OnModelCreating(modelBuilder);
        }

        //Login
        public DbSet<AllowPlayer> AllowPlayer { get; set; }
        public DbSet<AllUsers> AllUsers { get; set; }
        public DbSet<EasyUser> EasyUser { get; set; }
        public DbSet<Role> Role { get; set; }

        //Prize
        public DbSet<Prize> Prize { get; set; }

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
