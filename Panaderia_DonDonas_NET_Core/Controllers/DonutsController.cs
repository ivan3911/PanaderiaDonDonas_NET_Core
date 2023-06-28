using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Panaderia_DonDonas_NET_Core.DTOs;
using Panaderia_DonDonas_NET_Core.Entities;

namespace Panaderia_DonDonas_NET_Core.Controllers
{
    [ApiController]
    [Route("api/donuts")]
    public class DonutsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DonutsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DonutDTO>>> Get()
        {
            var donuts = await context.Donut.ToListAsync();

            return mapper.Map<List<DonutDTO>>(donuts);
            
        }

        [HttpPost]
        public async Task<ActionResult> Post(DonutCreatorDTO donutCreatorDTO) 
        {
            var donut = mapper.Map<Donut>(donutCreatorDTO);

            context.Add(donut);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
