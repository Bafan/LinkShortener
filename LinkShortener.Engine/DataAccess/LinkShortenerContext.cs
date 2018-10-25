using LinkShortener.Engine.Models;
using LinkShortener.Engine.Services;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Engine.DataAccess
{
    internal class LinkShortenerContext: DbContext
    {
        #region Public Members
        public DbSet<Link> Links { get; set; } 
        #endregion

        #region Private Members
        private IAppSettingService _appSettingService; 
        #endregion

        #region Constructor
        public LinkShortenerContext(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;
        } 
        #endregion

        #region Protected Implementation
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
        #endregion
    }
}
