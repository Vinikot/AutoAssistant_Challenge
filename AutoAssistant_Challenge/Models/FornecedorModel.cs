namespace AutoAssistant_Challenge.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public PessoaModel Pessoa { get; set;}
        public string Reputacao { get; set; }
        public ICollection<ProdutoFornecedorModel> ProdutoFornecedor { get; set; }
    }
}
