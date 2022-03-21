using LanchesMac.Models;
using LanchesMac.Repositories;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository)
        {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List(string categoria)
        {
            //ViewBag.Lanche = "Lanches";
            //ViewData["Categoria"] = "Categoria";

            //var lanches = _lancheRepository.Lanches;
            //return View(lanches)

            string _categoria = categoria;
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            // Verifica se a categoria foi informada. Caso não seja...
            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoria = "Todos os lanches";
            } else // Caso a categoria tenha sido informada...
            {
                // Retorna as que possuem categoria "Normal"
                if (string.Equals("Normal", _categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                        .OrderBy(l => l.Nome);
                }
                // Retorna as que possuem categoria "Natural"
                else
                {
                    lanches = _lancheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                        .OrderBy(l => l.Nome);
                }

                categoriaAtual = _categoria;
            }

            var lancheslistViewModel = new LancheListViewModel()
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };
            return View(lancheslistViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(x => x.LancheId == lancheId);
            if (lanche==null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(lanche);
        }
    }
}
