using AspDotNetCoreFromScratch.Data;
using AspDotNetCoreFromScratch.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCoreFromScratch.Controllers
{
    [Route("api/orders/{orderid}/items")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class OrderItemsController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public OrderItemsController(IDutchRepository repository, 
                                    IMapper mapper,
                                    ILogger<OrderItemsController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
                
        [HttpGet]
        public IActionResult GetItems(int orderId)
        {
            var order = _repository.GetOrderById(User.Identity.Name, orderId);
            if (order != null) return Ok(_mapper.Map<IEnumerable<OrderItemViewModel>>(order.Items));
            return NotFound();
        }

        [HttpGet("{itemId}")]
        public IActionResult GetItem(int orderId, int itemId)
        {
            var order = _repository.GetOrderById(User.Identity.Name, orderId);
            var item = order?.Items?.Where(i => i.Id == itemId).FirstOrDefault();
            if (item != null) return Ok(_mapper.Map<OrderItemViewModel>(item));
            return NotFound();
        }
        
    }
}
