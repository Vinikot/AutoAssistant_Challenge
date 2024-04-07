namespace AutoAssistant_Challenge.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set;}
        public TipoProdutoModel TipoProduto { get; set; }

        public ICollection<ProdutoFornecedorModel> ProdutoFornecedor { get; set; }
        public ICollection<ProdutoCompraModel> ProdutoCompra { get; set;}
    }
}
