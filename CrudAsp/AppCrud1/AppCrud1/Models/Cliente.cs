using System.ComponentModel.DataAnnotations;

namespace AppCrud1.Models
{
    public class Cliente
    {
        [Display(Name = "Código")]
        public int? IdCli { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        public string nomeCli { get; set; }

        [Display(Name = "Email Completo")]
        [Required(ErrorMessage = "O campo Email é obrigatorio")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string emailCli { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo Telefone é obrigatorio")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefone em formato inválido.")]
        public Int64 teleCli { get; set; }


        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O campo endereço é obrigatorio")]
        public string endCli { get; set; }

    }
}
