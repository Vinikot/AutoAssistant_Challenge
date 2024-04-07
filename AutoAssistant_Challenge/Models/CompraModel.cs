namespace AutoAssistant_Challenge.Models
{
    public class CompraModel
    {
        public int Id { get; set; }
        public int CompradorId { get; set; }
        public PessoaModel Comprador {  get; set; }
        public int FornecedorId { get; set; }
        public FornecedorModel Fornecedor { get; set; }
        public DateTime DataCompra { get; set; }
        public long CodigoCompra {  get; set; }
        public ICollection<ProdutoCompraModel> ProdutoCompra { get; set;}
    }
}
