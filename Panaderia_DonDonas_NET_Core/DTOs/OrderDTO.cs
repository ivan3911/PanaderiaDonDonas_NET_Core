using Panaderia_DonDonas_NET_Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Panaderia_DonDonas_NET_Core.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int NumberOfDonuts { get; set; }

        public DonutDTO donut { get; set; }  
        //public Donut? Donut { get; set; }
    }
}
