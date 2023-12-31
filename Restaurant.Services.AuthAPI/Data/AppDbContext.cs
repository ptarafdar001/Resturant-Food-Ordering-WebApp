﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.AuthAPI.Models;

namespace Restaurant.Services.AuthAPI.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationsUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }
    
        public DbSet<ApplicationsUser>ApplicationsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }
    }
}
