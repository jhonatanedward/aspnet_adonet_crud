﻿using System;
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
        private IAlunoBLL _alunoBll;

        public HomeController(ILogger<HomeController> logger, IAlunoBLL alunoBll)
        {
            _logger = logger;
            _alunoBll = alunoBll;
        }
        //// Get
        //public IActionResult Delete(int id)
        //{
        //    //_alunoBll.DeletarAluno(id);
        //    //return RedirectToAction("index");
        //    Aluno aluno = _alunoBll.GetAlunos().Single(a => a.Id == id);
        //    return View(aluno);
        //}
        public IActionResult Index()
        {
            List<Aluno> alunos = _alunoBll.GetAlunos();

            return View("Lista", alunos);
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

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                AlunoBLL _aluno = new AlunoBLL();
                _alunoBll.IncluirAluno(aluno);
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
        public IActionResult Edit(int id)
        {
            Aluno aluno = _alunoBll.GetAlunos().Where(x => x.Id == id).Single();
            return View(aluno);
        }
        [HttpPost]
        public IActionResult Edit([Bind(
            nameof(Aluno.Id),
            nameof(Aluno.Sexo),
            nameof(Aluno.Email),
            nameof(Aluno.Nascimento))]
        Aluno aluno)
        {
            aluno.Nome = _alunoBll.GetAlunos().Single(a => a.Id == aluno.Id).Nome;

            if (ModelState.IsValid)
            {
                _alunoBll.AtualizarAluno(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }
        public IActionResult Delete(int id)
        {
            _alunoBll.DeletarAluno(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Aluno aluno = _alunoBll.GetAlunos().Single(a => a.Id == id);
            return View(aluno);
        }
        public IActionResult Procurar(string procurarPor, string criterio)
        {
            if(procurarPor == "Email")
            {
                Aluno aluno = _alunoBll.GetAlunos().SingleOrDefault(a => a.Email == criterio);
                return View(aluno);
            }
            else
            {
                Aluno aluno = _alunoBll.GetAlunos().SingleOrDefault(a => a.Nome == criterio);
                return View(aluno);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
