using System.ComponentModel.DataAnnotations.Schema;

namespace AutoAssistant_Challenge.Models
{
    public class TipoProdutoModel
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string Descricao { get; set; }
    }
}
