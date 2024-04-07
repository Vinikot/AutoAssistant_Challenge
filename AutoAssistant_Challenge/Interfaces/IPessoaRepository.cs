using AutoAssistant_Challenge.Models;

namespace AutoAssistant_Challenge.Interfaces
{
    public interface IPessoaRepository
    {
        ICollection<PessoaModel> GetPessoas();
        PessoaModel GetPessoa(int id);
        PessoaModel GetPessoa(string nome);
        bool PessoaExists(int pessoaId);
        bool CreatePessoa(PessoaModel pessoa);
        bool UpdatePessoa(PessoaModel pessoa);
        bool DeletePessoa(PessoaModel pessoa);
        bool Save();
    }
}
