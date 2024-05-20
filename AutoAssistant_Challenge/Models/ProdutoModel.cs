using System.ComponentModel.DataAnnotations.Schema;

namespace AutoAssistant_Challenge.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string Descricao { get; set;}

        public TipoProdutoModel TipoProduto { get; set; }

        public ICollection<ProdutoFornecedorModel> ProdutoFornecedor { get; set; }
        public ICollection<ProdutoCompraModel> ProdutoCompra { get; set;}
    }
}
