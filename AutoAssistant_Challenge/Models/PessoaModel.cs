using System.ComponentModel.DataAnnotations.Schema;

namespace AutoAssistant_Challenge.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }

        public EnderecoModel Endereco { get; set;}

        [Column(TypeName = "varchar(50)")]
        public string Nome { get; set;}

        public Sexo Sexo { get; set;}

        public long Telefone {  get; set;}

        [Column(TypeName = "varchar(30)")]
        public string Email { get; set;}

        public long Cnpj {  get; set;}

        [Column(TypeName = "varchar(20)")]
        public string Senha { get; set;}
    }
}
