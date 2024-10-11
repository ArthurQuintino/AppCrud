using System.ComponentModel.DataAnnotations;

namespace AppCrud1.Models
{
    public class Usuario
    {
        [Display(Name = "Código")]
        public int? IdUsu { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage ="O campo nome é obrigatorio")]
        public string nomeUsu { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "O campo Cargo é obrigatorio")]
        public string Cargo { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "O campo Nascimento é obrigatorio")]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }

    }
}
