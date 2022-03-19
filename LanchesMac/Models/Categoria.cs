using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    // [Table("Categorias")] Nao e necessario pois sua definicao ja existe no contexto
    public class Categoria
    {
        // [Key] Como o nome e ClasseId, o Entity reconhece automaticamente que é a chave primária
        public int CategoriaId { get; set; }
        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        public string CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        // Uma categoria pode conter um ou mais lanches
        public List<Lanche> Lanches { get; set; }
    }
}
