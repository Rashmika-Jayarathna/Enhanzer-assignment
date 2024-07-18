using Deals.API.Data;
using Deals.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Deals.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DealsController : Controller
    {
        private readonly DealsDbContext dealsDbContext;

        public DealsController(DealsDbContext dealsDbContext)
        {
            this.dealsDbContext = dealsDbContext;
        }
        //get all deals
        [HttpGet]
        public async Task<IActionResult> GetAllDeals()
        {

            var deals = await dealsDbContext.Deals.ToListAsync();
            return Ok(deals);

        }

        //get a single deal
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetADeal")]
        public async Task<IActionResult> GetADeal([FromRoute] Guid id)
        {

            var deal = await dealsDbContext.Deals.FirstOrDefaultAsync(x => x.Id == id);

            if (deal != null)
            {
            return Ok(deal);

            }
            return NotFound("Card not found");

        }

        //Add a single deal
        [HttpPost]
        public async Task<IActionResult> AddDeal([FromBody] Deal deal)
        {

            deal.Id = Guid.NewGuid();

            await dealsDbContext.Deals.AddAsync(deal);
            await dealsDbContext.SaveChangesAsync();

            return CreatedAtAction( nameof(GetADeal), new { id = deal.Id}, deal);
            
        }

        //Update a card

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateDeal([FromRoute] Guid id, [FromBody] Deal deal)
        {
            var existingDeal = await dealsDbContext.Deals.FirstOrDefaultAsync(x => x.Id == id);

            if (existingDeal != null)
            {
                existingDeal.Size = deal.Size;
                existingDeal.category = deal.category;
                existingDeal.Employee = deal.Employee;
                existingDeal.Location = deal.Location;
                existingDeal.Pipeline = deal.Pipeline;
                existingDeal.Stage = deal.Stage;
                existingDeal.LastUpdated = DateTime.Now;

                await dealsDbContext.SaveChangesAsync();

                return Ok(existingDeal);

            }
            return NotFound("Card not found");


        }


        //Delete a card

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteDeal([FromRoute] Guid id)
        {
            var existingDeal = await dealsDbContext.Deals.FirstOrDefaultAsync(x => x.Id == id);

            if (existingDeal != null)
            {
                dealsDbContext.Remove(existingDeal);

                await dealsDbContext.SaveChangesAsync();

                return Ok(existingDeal);

            }
            return NotFound("Card not found");


        }
         
    }
}
