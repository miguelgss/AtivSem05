using LanchesMac.Models;
using System.Collections.Generic;

namespace LanchesMac.ViewModel
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
