namespace AutoAssistant_Challenge.Models
{
    public class ProdutoFornecedorModel
    {
        public int ProdutoId { get; set; }
        public int FornecedorId { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public ProdutoModel Produto { get; set; }
        public FornecedorModel Fornecedor { get; set; }
    }
}
