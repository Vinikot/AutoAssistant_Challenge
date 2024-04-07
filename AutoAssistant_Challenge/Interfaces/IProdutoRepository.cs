using AutoAssistant_Challenge.Models;

namespace AutoAssistant_Challenge.Interfaces
{
    public interface IProdutoRepository
    {
        ICollection<ProdutoModel> GetProdutos();
        ProdutoModel GetProduto(int id);
        ProdutoModel GetProduto(string nome);
        bool ProdutoExists(int produtoId);
        bool CreateProduto(ProdutoModel produto, int fornecedorId, int compraId);
        bool UpdateProduto(ProdutoModel produto, int fornecedorId, int compraId);
        bool DeleteProduto(ProdutoModel produto);
        bool Save();
    }
}
