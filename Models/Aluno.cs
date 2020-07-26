using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc_BO.Models
{
    public class Aluno
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage= "Informe o nome do Cliente")]
        [StringLength(50, MinimumLength=5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres")]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o sexo do Cliente ")]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Email: ")]
        [EmailAddress(ErrorMessage = "Email inválido !")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Nascimento")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Nascimento { get; set; }
        public string Foto { get; set; }
        public string Texto { get; set; }
    }
}
