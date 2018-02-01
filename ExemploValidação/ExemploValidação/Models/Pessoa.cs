using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExemploValidação.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        public string Nome { get; set; }

        [StringLength(50,MinimumLength = 5, ErrorMessage = "A observação deve ter de 5 a 50 caracteres")]
        public string Observacao { get; set; }

        [Range(18,50,ErrorMessage = "A idade deve ser de 18 a 50 anos")]
        public int Idade { get; set; }

        [RegularExpression(@"\w+([-+.']\w)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email errado")]
        public string Email { get; set; }

        [RegularExpression(@"[a-zA-Z]{5,15}", ErrorMessage = "Login deve possuir somente letras, de 5 a 15 caracteres")]
        [Required(ErrorMessage = "O login deve ser preenchido")]
        [Remote("LoginUnico", "Pessoa", ErrorMessage = "Este nome de login ja existe")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha deve ser digitada")]
        public string Senha { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage = "As senhas não coincidem")]
        public string ConfirmarSenha { get; set; }
    }
}