using AutoAssistant_Challenge.Models;

namespace AutoAssistant_Challenge.Dto
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public long Telefone { get; set; }
        public string Email { get; set; }
    }
}
