using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Context
{
    public class AirBnbContext:DbContext
    {
        public DbSet<Acommodation> Acommodations{ get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=WILLIAM\\SQLEXPRESS; Initial Catalog= AirbnbContext; User Id=sa; Password=sa132");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().Ignore(c => c.UnvaibleDays);

            modelBuilder.Entity<Schedule>().Ignore(c => c.Invalid);
            modelBuilder.Entity<Schedule>().Ignore(c => c.Valid);
            modelBuilder.Entity<Schedule>().Ignore(c => c.Notifications);

            modelBuilder.Entity<Furniture>().Ignore(c => c.Invalid);
            modelBuilder.Entity<Furniture>().Ignore(c => c.Valid);
            modelBuilder.Entity<Furniture>().Ignore(c => c.Notifications);

            modelBuilder.Entity<Acommodation>().Ignore(c => c.Invalid);
            modelBuilder.Entity<Acommodation>().Ignore(c => c.Valid);
            modelBuilder.Entity<Acommodation>().Ignore(c => c.Notifications);

            modelBuilder.Entity<User>().Ignore(c => c.Invalid);
            modelBuilder.Entity<User>().Ignore(c => c.Valid);
            modelBuilder.Entity<User>().Ignore(c => c.Notifications);



        }
    }
    

}
