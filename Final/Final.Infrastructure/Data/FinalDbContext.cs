using Final.ApplicationCore.Entitity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Infrastructure.Data
{
    public class FinalDbContext:DbContext
    {
        public FinalDbContext(DbContextOptions<FinalDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; } //Here is s at the end
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Roomtype> Roomtypes { get; set; }
        public DbSet<Roomservice> Roomservices { get; set; }
        public DbSet<User> Users { get; set; }

        // Many DbSets, they are represented as properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(ConfigureCustomer);
            modelBuilder.Entity<Room>(ConfigureRoom);
            modelBuilder.Entity<Roomtype>(ConfigureRoomtype);
            modelBuilder.Entity<Roomservice>(ConfigureRoomservice);
            modelBuilder.Entity<User>(ConfigureUser);

        }



        //Customer
        private void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.RoomNo);
            builder.HasOne(r => r.Room).WithMany(c => c.Customers).HasForeignKey(c => c.RoomNo);
            builder.Property(c => c.CName).HasMaxLength(20);
            builder.Property(c => c.Address).HasMaxLength(100);
            builder.Property(c => c.Phone).HasMaxLength(20);
            builder.Property(c => c.Email).HasMaxLength(40);
            builder.Property(c => c.Checkin); 
            builder.Property(c => c.TotalPersons);
            builder.Property(c => c.BookingDays);
            builder.Property(c => c.Advance).HasColumnType("decimal(5, 2)");
        }
        //Room
        private void ConfigureRoom(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");
            builder.HasKey(r=> r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.HasOne(r => r.Roomtype).WithMany(rt=>rt.Rooms).HasForeignKey(r => r.RTCode);
            builder.Property(r => r.Status); 

        }
        //RoomService
        private void ConfigureRoomservice(EntityTypeBuilder<Roomservice> builder)
        {
            builder.ToTable("Roomservice");
            builder.HasKey(rs => rs.Id);
            builder.Property(rs => rs.Id).ValueGeneratedOnAdd();
            builder.HasOne(r => r.Room).WithMany(rs => rs.Roomservices).HasForeignKey(rs => rs.RoomNo);
            builder.Property(rs => rs.SDesc).HasMaxLength(50);
            builder.Property(c => c.Amount).HasColumnType("decimal(5, 2)");
            builder.Property(c => c.ServiceDate);


        }
        //Roomtype
        private void ConfigureRoomtype(EntityTypeBuilder<Roomtype> builder)
        {
            builder.ToTable("Roomtype");
            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.Id).ValueGeneratedOnAdd();
            builder.Property(rt =>rt.RTDesc).HasMaxLength(20);
            builder.Property(rt => rt.Rent).HasColumnType("decimal(5, 2)");
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.FirstName).HasMaxLength(128);
            builder.Property(u => u.LastName).HasMaxLength(128);
            builder.Property(u => u.HashedPassword).HasMaxLength(1024);
            builder.Property(u => u.Salt).HasMaxLength(1024);
        }
        }
}
