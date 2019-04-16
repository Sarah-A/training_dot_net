using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspDotNetCoreFromScratch.Data;
using Microsoft.Extensions.Logging;
using DutchTreat.Data.Entities;
using AutoMapper;
using AspDotNetCoreFromScratch.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using AspDotNetCoreFromScratch.Data.Entities;

namespace AspDotNetCoreFromScratch.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<StoreUser> _userManager;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IDutchRepository repository,
                                IMapper mapper,
                                UserManager<StoreUser> userManager,
                                ILogger<OrdersController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderViewModel>> GetAllOrdersByUser(bool includeItems = true)
        {
            var userName = User.Identity.Name;

            var orders = _repository.GetAllOrdersByUser(userName , includeItems);

            if (orders != null)
            {
                return Ok(_mapper.Map<IEnumerable<OrderViewModel>>(orders));
            }
            else
            {
                return BadRequest("Failed to find orders");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<OrderViewModel> GetOrder(int id)
        {
            var order = _repository.GetOrderById(User.Identity.Name, id);

            if (order != null)
            {
                return Ok(_mapper.Map<OrderViewModel>(order));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostNewOrder([FromBody]OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid order details");
            }

            if (orderViewModel.OrderDate == null)
            {
                orderViewModel.OrderDate = DateTime.Now;
            }

            var newOrder = _mapper.Map<Order>(orderViewModel);

            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (currentUser == null) return BadRequest();
            newOrder.User = currentUser;
            
            _repository.AddEntity(newOrder);
            if (_repository.SaveAll())
            {
                return Created($"/api/orders/{newOrder.Id}", 
                                _mapper.Map<OrderViewModel>(newOrder));
            }
            else
            {
                return BadRequest("Failed to save new order.");
            }
        }
        
    }
}
