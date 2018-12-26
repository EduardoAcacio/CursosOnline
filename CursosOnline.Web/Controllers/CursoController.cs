using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CursosOnline.Web.Models;
using CursosOnline.Web.Util;
using CursosOnline.Domain.Cursos;

namespace CursosOnline.Web.Controllers
{
    public class CursosController : Controller
    {
        private readonly ArmazenadorDeCurso _armazenadorDeDurso;

        public CursosController(ArmazenadorDeCurso armazenadorDeDurso)
        {
            _armazenadorDeDurso = armazenadorDeDurso;
        }

        public IActionResult Index()
        {
            var cursos = new List<CursoParaListagemDto>();

            return View("Index", PaginatedList<CursoParaListagemDto>.Create(cursos, Request));
        }

        public IActionResult Novo()
        {
            return View("NovoOuEditar", new CursoDto());
        }

        [HttpPost]
        public IActionResult Salvar(CursoDto model)
        {
            _armazenadorDeDurso.Armazenar(model);
            
            return Ok();
        }
    }
}