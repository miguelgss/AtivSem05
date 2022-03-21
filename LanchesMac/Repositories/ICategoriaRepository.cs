using LanchesMac.Models;
using System.Collections.Generic;

namespace LanchesMac.Repositories
{
    public interface ICategoriaRepository
    {
        public IEnumerable<Categoria> Categorias { get; }
    }
}