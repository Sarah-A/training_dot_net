using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspDotNetCoreFromScratch.Data;
using Microsoft.Extensions.Logging;
using DutchTreat.Data.Entities;

namespace AspDotNetCoreFromScratch.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IDutchRepository repository, ILogger<OrdersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            var orders = _repository.GetOrders();

            if (orders != null)
            {
                return Ok(orders);
            }
            else
            {
                return BadRequest("Failed to find orders");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = _repository.GetOrderById(id);

            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return NotFound();
            }
        }
        
    }
}
