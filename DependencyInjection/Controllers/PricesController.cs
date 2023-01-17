using DependencyInjection.Domain.DataAccess;
using DependencyInjection.Domain.Model;
using DependencyInjection.ProductManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DependencyInjection.Controllers
{
    public record PriceChangeDto(string User, decimal PercPriceChange);

    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly ProductDbContext context;
        private readonly PriceManager pm;
        private readonly LogManager lm;

        public PricesController(ProductDbContext context, PriceManager pm, LogManager lm)
        {
            this.context = context;
            this.pm = pm;
            this.lm = lm;
        }

        [HttpPost]
        [Route("fill")]
        public async Task<IActionResult> FillWithDemoData()
        {
            context.Prices.Add(new Price
            {
                Product = "Apples",
                ProductPrice = 100
            });
            await context.SaveChangesAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost]
        public async Task<IActionResult> PriceChange(PriceChangeDto priceChange)
        {
            pm.ChangePrices(priceChange.PercPriceChange);
            lm.AddLog(priceChange.User, $"Prices changed by {priceChange.PercPriceChange * 100}");
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
