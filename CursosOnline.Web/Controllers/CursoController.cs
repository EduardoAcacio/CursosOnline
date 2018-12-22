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
        public IActionResult Index()
        {
            return View("Index", PaginatedList<CursoParaListagemDto>.Create(CursosController, Request));
        }

        public IActionResult Novo()
        {
            return View("NovoOuEditar", new CursoDto());
        }

        [HttpPost]
        public IActionResult Salvar(CursoDto model)
        {
            return ok;
        }
    }
}