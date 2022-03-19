using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    // [Table("Lanches")] Nao e necessario pois sua definicao ja existe no contexto
    public class Lanche
    {
        // [Key] Como o nome e ClasseId, o Entity reconhece automaticamente que é a chave primária
        public int LancheId { get; set; }

        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome do lanche")]
        public string Nome { get; set; }
        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe uma descrição curta do lanche")]
        public string DescricaoCurta { get; set; }
        [StringLength(200, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe a descrição do lanche")]
        public string DescricaoDetalhada { get; set; }
        [Column(TypeName="decimal(18,2)")]
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Informe o preço do lanche")]
        public decimal Preco { get; set; }
        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }
        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }
        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }
        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        // Definição de foreign key
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
