using AutoAssistant_Challenge.Models;

namespace AutoAssistant_Challenge.Interfaces
{
    public interface IFornecedorRepository
    {
        ICollection<FornecedorModel> GetFornecedores();
        FornecedorModel GetFornecedor(int id);
        FornecedorModel GetFornecedor(string nome);
        bool FornecedorExists(int fornecedorId);
        bool CreateFornecedor(FornecedorModel fornecedor);
        bool UpdateFornecedor(FornecedorModel fornecedor);
        bool DeleteFornecedor(FornecedorModel fornecedor);
        bool Save();
    }
}
