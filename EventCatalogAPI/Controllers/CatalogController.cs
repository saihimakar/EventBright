using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Catalog")]
    public class CatalogController : Controller
    {
        private readonly CatalogContext _context;
        private readonly IConfiguration _config;
        public CatalogController(CatalogContext context,
            IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogTypes()
        {
            var items = await _context.EventTypes.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("items/{id:int}")]
        public async Task<IActionResult> GetItemsById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Incorrect Id!");
            }

            var item = await _context.EventItems
                   .SingleOrDefaultAsync(c => c.Id == id);

            if (item != null)
            {
                item.PictureUrl =
                    item.PictureUrl
                    .Replace("http://externalcatalogbaseurltobereplaced"
                    , _config["ExternalCatalogBaseUrl"]);
                return Ok(item);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items([FromQuery] int pageSize = 6,
                [FromQuery] int pageIndex = 0)
        {
            var itemsCount = await _context.EventItems.LongCountAsync();

            var items = await _context.EventItems
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemsCount,
                Data = items
            };
            return Ok(model);

        }


        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(
                c => c.PictureUrl = c.PictureUrl
                    .Replace("http://externalcatalogbaseurltobereplaced"
                    , _config["ExternalCatalogBaseUrl"])
                );
            return items;
        }
    }
}
