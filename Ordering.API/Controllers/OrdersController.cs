using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.API.Application.Commands;
using Ordering.API.Application.Queries;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProductQueries _productQueries;

        public OrdersController(IMediator mediator, IProductQueries productQueries)
        {
            _mediator = mediator;
            _productQueries = productQueries;
        }

        // POST api/orders
        [HttpPost]
        [Route("placeorder")]
        public async Task<IActionResult>  PlaceOrder([FromBody] CreateOrderCommand createOrderCommand)
        {
            var tasks = createOrderCommand.OrderItems
                .Select(item => _productQueries.GetProductBySKUAsync(item.SKU)
                                    .ContinueWith((productAsync) => 
                                    {
                                        var product = productAsync.Result;
                                        if (product != null)
                                        {
                                            item.ProductId = product.Id;
                                            item.UnitPrice = product.UnitPrice;
                                            item.ProductName = product.ProductName;
                                        }
                                    }));

            await Task.WhenAll(tasks);
            var commandResult = await _mediator.Send(createOrderCommand);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}