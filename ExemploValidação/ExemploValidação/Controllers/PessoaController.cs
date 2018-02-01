using ExemploValidação.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExemploValidação.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            var pessoa = new Pessoa();          
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Index(Pessoa pessoa)
        {
            /* validações server-side
            if (string.IsNullOrEmpty(pessoa.Nome))
            {
                ModelState.AddModelError("Nome", "O campo nome é obrigatório");
            }

            if (pessoa.Senha != pessoa.ConfirmarSenha)
            {
                ModelState.AddModelError("", "As senhas não conferem");
            }*/


            if (ModelState.IsValid)
            {
                return View("Resultado", pessoa);
            }

            return View(pessoa);
        }

        public ActionResult Resultado(Pessoa pessoa)
        {
            return View(pessoa);
        }

        public ActionResult LoginUnico(string login)
        {
            var bancoDeNomesDeExemplo = new Collection<string>
            {
                "Caue",
                "Anderson",
                "Brenda"
            };
            return Json(bancoDeNomesDeExemplo.All(x => x.ToLower() != login.ToLower()), JsonRequestBehavior.AllowGet);

        }
    }
}