using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataRepository
{
    public class EventMap
    {
        public EventMap(EntityTypeBuilder<Event> entityBuilder)
        {
            entityBuilder.HasKey(t => t.EventId);
            entityBuilder.Property(t => t.EventName).IsRequired();
            entityBuilder.Property(t => t.CategoryName).IsRequired();
            entityBuilder.Property(t => t.EventTime);
            entityBuilder.Property(t => t.Day).IsRequired();
            entityBuilder.Property(t => t.Month).IsRequired();
            entityBuilder.Property(t => t.Year).IsRequired();
            entityBuilder.Property(t => t.Hour).IsRequired();
            entityBuilder.Property(t => t.Minute).IsRequired();
            entityBuilder.Property(t => t.Address1).IsRequired();
            entityBuilder.Property(t => t.Address2).IsRequired();
            entityBuilder.Property(t => t.Address3).IsRequired();
            entityBuilder.Property(t => t.Address4).IsRequired();
            entityBuilder.Property(t => t.EventDescription).IsRequired();
            entityBuilder.Property(t => t.YoutubeUrl).IsRequired();
        }
    }
}
