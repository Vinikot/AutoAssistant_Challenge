using System.ComponentModel.DataAnnotations.Schema;

namespace AutoAssistant_Challenge.Models
{
    public class EnderecoModel
    {
        public int Id {  get; set; }

        [Column(TypeName = "varchar(9)")]
        public string Cep { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Logradouro { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Complemento { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Bairro { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Localidade { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string UF { get; set; }

        [Column(TypeName = "varchar(7)")]
        public string IBGE { get; set; }

        [Column(TypeName = "varchar(4)")]
        public string GIA { get; set; }

        [Column(TypeName = "varchar(2)")]
        public string DDD { get; set; }

        [Column(TypeName = "varchar(4)")]
        public string SIAFI { get; set; }
    }
}
