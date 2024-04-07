namespace AutoAssistant_Challenge.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public EnderecoModel Endereco { get; set;}
        public string Nome { get; set;}
        public Sexo Sexo { get; set;}
        public long Telefone {  get; set;}
        public string Email { get; set;}
        public long Cnpj {  get; set;}
        public string Senha { get; set;}
    }
}
