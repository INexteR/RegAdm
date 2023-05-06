using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RegAdmModel.Entities;
using RegAdmModel.Testing;

namespace RegAdmModel
{
    internal partial class RegAdmContext : DbContext
    {
        private readonly string connectionString;

        public RegAdmContext(string connectionString)
            => this.connectionString = connectionString;

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                _ = optionsBuilder.UseSqlite(connectionString);

                optionsBuilder.EnableSensitiveDataLogging()
                    .UseSqlite($"Data Source={connectionString}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adm = "Администратор";
            modelBuilder.Entity<User>()
                .ToTable(t => t.HasCheckConstraint("Role", $"Role IN ('{adm}', 'Старший {adm}')"))
                .HasData(Data.Users);

            modelBuilder.Entity<RoomType>().HasData(Data.RoomTypes);
            modelBuilder.Entity<Room>().HasData(Data.Rooms);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
