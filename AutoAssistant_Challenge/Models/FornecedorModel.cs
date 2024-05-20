using System.ComponentModel.DataAnnotations.Schema;

namespace AutoAssistant_Challenge.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Nome { get; set; }

        public PessoaModel Pessoa { get; set;}

        [Column(TypeName = "varchar(100)")]
        public string Reputacao { get; set; }

        public ICollection<ProdutoFornecedorModel> ProdutoFornecedor { get; set; }
    }
}
