using LinkShortener.Engine.Models;
using LinkShortener.Engine.Services;
using Microsoft.EntityFrameworkCore;      
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace LinkShortener.Engine.DataAccess
{
    internal class LinkShortenerContext: DbContext
    {        
        public DbSet<Link> Links { get; set; }

        private IAppSettingService _appSettingService;

        public LinkShortenerContext(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseMySQL(_appSettingService.GetConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Link>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Origin);
                entity.Property(e => e.Shorten);
            });
        }
    }
}
