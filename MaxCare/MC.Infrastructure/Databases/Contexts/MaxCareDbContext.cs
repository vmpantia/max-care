﻿using MC.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MC.Infrastructure.Databases.Contexts
{
    public sealed class MaxCareDbContext : DbContext
    {
        public MaxCareDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(group =>
            {
                group.HasMany(group => group.Members)
                .WithOne(member => member.Group)
                .HasForeignKey(member => member.GroupId)
                .IsRequired(false);
            });

            modelBuilder.Entity<Member>(member =>
            {
                member.HasOne(member => member.Group)
                .WithMany(group => group.Members)
                .HasForeignKey(member => member.GroupId)
                .IsRequired(false);
            });
        }
    }
}