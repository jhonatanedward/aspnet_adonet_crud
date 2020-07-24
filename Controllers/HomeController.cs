using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc_BO.Models;

namespace Mvc_BO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] Aluno aluno)
        {
            //if (string.IsNullOrEmpty(aluno.Nome))
            //    ModelState.AddModelError("Nome", "O Nome é obrigatório");
            //if (string.IsNullOrEmpty(aluno.Sexo))
            //    ModelState.AddModelError("Nome", "O Sexo é obrigatório");
            //if (string.IsNullOrEmpty(aluno.Email))
            //    ModelState.AddModelError("Email", "O Email é obrigatório");
            //if (aluno.Nascimento <= DateTime.Now.AddYears(-18))
            //    ModelState.AddModelError("Nascimento", "Data de nascimento inválida.");

            if(!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                AlunoBLL _aluno = new AlunoBLL();
                _aluno.IncluirAluno(aluno);
                return RedirectToAction("Index");
            }
            //if(aluno?.Nome == null || aluno?.Email == null || aluno.Sexo == null)
            //{
            //    ViewBag.Erro = "Dados Inválidos";
            //    return View();
            //}
            //else
            //{
            
            //}
        }

        public IActionResult Index()
        {
            AlunoBLL _aluno = new AlunoBLL();

            List<Aluno> alunos = _aluno.GetAlunos();

            return View("Lista", alunos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
