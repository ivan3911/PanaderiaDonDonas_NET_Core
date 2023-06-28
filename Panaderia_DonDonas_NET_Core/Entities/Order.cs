using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Panaderia_DonDonas_NET_Core.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(maximumLength:20, ErrorMessage ="El campo {0} no debe tener mas de {1} carácteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 170, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres")]
        public string Address { get; set; }

        [Range(1,99)]
        public int NumberOfDonuts { get; set; }

        [ForeignKey("Donut")]
        public int Donut_Id { get; set; }

        public Donut? Donut { get; set; }


    }
}
