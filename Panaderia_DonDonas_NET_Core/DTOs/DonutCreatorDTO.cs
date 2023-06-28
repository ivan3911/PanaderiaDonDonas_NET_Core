using System.ComponentModel.DataAnnotations;

namespace Panaderia_DonDonas_NET_Core.DTOs
{
    public class DonutCreatorDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres")]
        public string DonutName { get; set; }
    }
}
