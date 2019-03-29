using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventItem> EventItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>(ConfigureEventType);
            modelBuilder.Entity<EventItem>(ConfigureEventItem);
        }

        private void ConfigureEventType(EntityTypeBuilder<EventType> builder)
        {
            builder.ToTable("EventTypes");
            builder.Property(c => c.Id).IsRequired().ForSqlServerUseSequenceHiLo("event_type_hilo");
            builder.Property(c => c.Type).IsRequired().HasMaxLength(100);
        }

        private void ConfigureEventItem(EntityTypeBuilder<EventItem> builder)
        {
            builder.ToTable("EventItem");
            builder.Property(i => i.Id).IsRequired().ForSqlServerUseSequenceHiLo("event_item_hilo");
            builder.Property(n => n.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Price).IsRequired();
            builder.HasOne(t => t.EventType).WithMany().HasForeignKey(c => c.EventTypeId);
        }


    }
}
