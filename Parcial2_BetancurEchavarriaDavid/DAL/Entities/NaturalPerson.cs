using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Parcial2_BetancurEchavarriaDavid.DAL.Entities
{
    public class NaturalPerson : Entity
    {
        [Display(FullName = "Pais")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int BirthYear { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Age { get; set; }

    }
}
