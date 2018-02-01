using GetPostModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetPostModel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var pessoa = new Pessoa()
            {
                PessoaId = 1,
                Nome = "Caue Andrade",
                Twitter = "@caue.andrade"
            };

            /*
            ViewData["PessoaId"] = pessoa.PessoaId;
            ViewData["Nome"] = pessoa.Nome;
            ViewData["Twitter"] = pessoa.Twitter;
            */

            /*
            ViewBag.PessoaId = pessoa.PessoaId;
            ViewBag.NomeDaPessoa = pessoa.Nome;
            ViewBag.TwitterDaPessoa = pessoa.Twitter;
            */
            return View(pessoa); // Para usar view Tipada
        }

        /*
        [HttpPost]
        public ActionResult Lista(int PessoaId, string Nome, string Twitter)
        {
            ViewData["PessoaId"] = PessoaId;
            ViewData["Nome"] = Nome;
            ViewData["Twitter"] = Twitter;

            return View();
        }

        [HttpPost]
        /*public ActionResult Lista(FormCollection form)
        {
            ViewData["PessoaId"] = form["PessoaId"];
            ViewData["Nome"] = form["Nome"];
            ViewData["Twitter"] = form["Twitter"];

            return View();

        }

        [HttpPost]
        /*public ActionResult Lista(Pessoa pessoa)
        {
            ViewData["PessoaId"] = pessoa.PessoaId;
            ViewData["Nome"] = pessoa.Nome;
            ViewData["Twitter"] = pessoa.Twitter;

            return View();

        }*/

        [HttpPost]
        public ActionResult Lista(Pessoa pessoa)
        {
            return View(pessoa);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}