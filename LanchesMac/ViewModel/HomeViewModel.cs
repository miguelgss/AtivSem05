using LanchesMac.Models;
using System.Collections.Generic;

namespace LanchesMac.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}
