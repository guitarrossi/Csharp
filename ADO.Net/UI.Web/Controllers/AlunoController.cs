using AulasCsharp.Aplicacao;
using AulasCsharp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            var appAluno = new AlunoAplicacao();

            var listaDeAlunos = appAluno.ListarTodos();

            return View(listaDeAlunos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var appAluno = new AlunoAplicacao();
                appAluno.Inserir(aluno);
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        public ActionResult Editar(int id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.ListarPorId(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Aluno aluno, int id)
        {
            if (ModelState.IsValid)
            {
                var appAluno = new AlunoAplicacao();
                appAluno.Alterar(aluno, id);
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        public ActionResult Detalhes(int id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.ListarPorId(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

    }
}