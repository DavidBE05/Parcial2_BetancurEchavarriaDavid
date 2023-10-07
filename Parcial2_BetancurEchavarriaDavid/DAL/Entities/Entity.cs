using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Parcial2_BetancurEchavarriaDavid.DAL.Entities
{
    public class Entity
    {
        [Required]
        public Guid Id { get; set; } 

        [Display(Name = "Fecha de creación")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Fecha de modificacion")]
        public DateTime? ModifiedDate { get; set; }
    }
}
