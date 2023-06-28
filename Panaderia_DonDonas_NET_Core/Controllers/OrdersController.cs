using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Panaderia_DonDonas_NET_Core.DTOs;
using Panaderia_DonDonas_NET_Core.Entities;

namespace Panaderia_DonDonas_NET_Core.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public OrdersController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> Get()
        {
            var orders = await context.Order.Include(x => x.Donut).ToListAsync();

            return mapper.Map<List<OrderDTO>>(orders);
                        
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<OrderDTO>>> Get(int id)
        {
            var existOrder = await context.Order.FirstOrDefaultAsync(x => x.Id == id);

            if (existOrder ==null)
                return NotFound($"No existe la venta con id:{id}");

            var order = await context.Order.Include(x => x.Donut)
                            .Where(x => x.Id == id)
                            .ToListAsync();

            return mapper.Map<List<OrderDTO>>(order);


        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post(OrderCreatorDTO orderCreatorDTO)
        {
            var existDonut = await context.Donut.AnyAsync(x => x.Donut_Id == orderCreatorDTO.Donut_Id);

            if (!existDonut)
                return NotFound($"No existe la dona con id:{orderCreatorDTO.Donut_Id}");

            var order = mapper.Map<Order>(orderCreatorDTO);

            context.Add(order);

            await context.SaveChangesAsync();
            

            return Ok();
        }
    }
}
