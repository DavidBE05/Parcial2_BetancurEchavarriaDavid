using System;
using System.ComponentModel.DataAnnotations;

namespace Parcial2_BetancurEchavarriaDavid.DAL.Entities
{
    public class NaturalPerson : Entity
    {

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int BirthYear { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Age { get; set; }

    }
}
