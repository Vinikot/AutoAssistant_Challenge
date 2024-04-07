using AutoAssistant_Challenge.Models;

namespace AutoAssistant_Challenge.Dto
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoProdutoModel TipoProduto { get; set; }
    }
}
