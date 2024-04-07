namespace AutoAssistant_Challenge.Models
{
    public class ProdutoCompraModel
    {
        public int ProdutoId { get; set; }
        public int CompraId { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public ProdutoModel Produto { get; set; }
        public CompraModel Compra { get; set; }
    }
}
