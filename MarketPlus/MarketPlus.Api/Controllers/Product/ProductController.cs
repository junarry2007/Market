using Azure.Core;
using MarketPlus.Application.Products.AddProduct;
using MarketPlus.Application.Products.DeleteProduct;
using MarketPlus.Application.Products.GetProduct;
using MarketPlus.Application.Products.SearchProduct;
using MarketPlus.Application.Products.UpdateProduct;
using MarketPlus.Infrastructure.Cache;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace MarketPlus.Api.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ICacheService<Dictionary<bool, string>> _cacheService;
        public ProductController(ISender sender, ICacheService<Dictionary<bool,string>> cacheService)
        {
            _sender = sender;
            _cacheService = cacheService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var query = new GetProductQuery();
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var query = new SearchProductQuery(id);
            var result = await _sender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                var cache = _cacheService.Get("States");
                var state = cache is not null ? cache.FirstOrDefault(x => x.Key ==  result.Value.Status).Value : null;
                result.Value.StatusHomologate = state;
            }
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post(ProductRequest request, CancellationToken cancellationToken)
        {
            var command = new AddProductCommand(request.Name, request.Description, request.Status, request.Stock,request.Amount,request.Currency);
            var result = await _sender.Send(command, cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return new CreatedAtRouteResult("GetById", new { id = result.Value }, result.Value);

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ProductRequest request, CancellationToken cancellationTokene)
        {
            var command = new UpdateProductCommand(id, request.Name, request.Description, request.Status, request.Stock, request.Amount,request.Currency);
            var result = await _sender.Send(command, cancellationTokene);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationTokene)
        {
            var command = new DeleteProductCommand(id);
            var result = await _sender.Send(command, cancellationTokene);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }
    }
}
