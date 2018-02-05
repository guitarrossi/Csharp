using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulasCsharp.Dominio
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome do aluno")]
        public string Nome { get; set; }

        [DisplayName("Mãe do Aluno")]
        [Required(ErrorMessage = "Preencha o nome da mae do aluno")]
        public string Mae { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Preencha a data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        
    }
}
