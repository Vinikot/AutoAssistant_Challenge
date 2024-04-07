using AutoAssistant_Challenge.Models;

namespace AutoAssistant_Challenge.Interfaces
{
    public interface IEnderecoRepository
    {
        ICollection<EnderecoModel> GetEnderecos();
        EnderecoModel GetEndereco(int id);
        bool EnderecoExists(int enderecoId);
        bool CreateEndereco(EnderecoModel endereco);
        bool UpdateEndereco(EnderecoModel endereco);
        bool DeleteEndereco(EnderecoModel endereco);
        bool Save();
    }
}
