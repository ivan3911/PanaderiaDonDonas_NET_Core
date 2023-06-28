using AutoMapper;
using Panaderia_DonDonas_NET_Core.DTOs;
using Panaderia_DonDonas_NET_Core.Entities;

namespace Panaderia_DonDonas_NET_Core.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DonutCreatorDTO, Donut>();
            CreateMap<Donut, DonutDTO>();

            CreateMap<OrderCreatorDTO, Order>();
            CreateMap<Order, OrderDTO>()
                .ForMember(orderDTO => orderDTO.donut, opciones => opciones.MapFrom(MapOrderDTODonut));



        }

        private DonutDTO MapOrderDTODonut(Order order, OrderDTO orderDTO) 
        {

            var newDonutDTO = new DonutDTO()
            {
                Donut_Id = order.Donut.Donut_Id,
                DonutName = order.Donut.DonutName
            }; 
            return newDonutDTO;
        }
    }
}
