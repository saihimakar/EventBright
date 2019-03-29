using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogSeed
    {

        public static void Seed(CatalogContext context)
        {           
            context.Database.Migrate();

            if(!context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetPreconfiguredCatalogTypes());
                context.SaveChanges();
            }
            if (!context.EventItems.Any())
            {
                context.EventItems.AddRange(GetPreconfiguredEventItems());
                context.SaveChanges();
            }

        }

        private static IEnumerable<EventType> GetPreconfiguredCatalogTypes()
        {
            return new List<EventType>()
            {

                new EventType()
                {
                    Type = "Sports & Fitness"
                },
                new EventType()
                {
                    Type = "Science & Tech"
                },
                new EventType()
                {
                    Type = "Travel & Outdoor"
                },

            };
        }

        static IEnumerable<EventItem> GetPreconfiguredEventItems()
        {
            return new List<EventItem>()
            {
                new EventItem() { EventTypeId=2, Description = "Shoes for next century", Name = "World Star", Price = 199.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventTypeId=1, Description = "will make you world champions", Name = "White Line", Price= 88.50M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new EventItem() { EventTypeId=2, Description = "You have already won gold medal", Name = "Prism White Shoes", Price = 129, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new EventItem() { EventTypeId=2, Description = "Olympic runner", Name = "Foundation Hitech", Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
                new EventItem() { EventTypeId=2, Description = "Roslyn Red Sheet", Name = "Roslyn White", Price = 188.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new EventItem() { EventTypeId=2, Description = "Lala Land", Name = "Blue Star", Price = 112, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                new EventItem() { EventTypeId=2, Description = "High in the sky", Name = "Roslyn Green", Price = 212, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },
                new EventItem() { EventTypeId=1, Description = "Light as carbon", Name = "Deep Purple", Price = 238.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8" },
                new EventItem() { EventTypeId=1, Description = "High Jumper", Name = "Addidas<White> Running", Price = 129, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9" },
                new EventItem() { EventTypeId=2, Description = "Dunker", Name = "Elequent", Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10" },
                new EventItem() { EventTypeId=1, Description = "All round", Name = "Inredeible", Price = 248.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new EventItem() { EventTypeId=2, Description = "Pricesless", Name = "London Sky", Price = 412, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12" },
                new EventItem() { EventTypeId=3, Description = "Tennis Star", Name = "Elequent", Price = 123, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new EventItem() { EventTypeId=3, Description = "Wimbeldon", Name = "London Star", Price = 218.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14" },
                new EventItem() { EventTypeId=3, Description = "Rolan Garros", Name = "Paris Blues", Price = 312, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15" }

            };
        }

    }
}
