using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsandoEntityFramework.Models
{
    public class pessoa
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Insira o nome da pessoa")]
        public string Nome { get; set; }

        public string Email { get; set; }
    }
}