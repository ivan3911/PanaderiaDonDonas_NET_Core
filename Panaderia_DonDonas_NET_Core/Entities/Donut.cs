using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Panaderia_DonDonas_NET_Core.Entities
{
    public class Donut
    {
        [Key]
        public int Donut_Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres")]
        public string DonutName { get; set; }
        
        public List<Order>? Order { get; set; }

    }
}
    