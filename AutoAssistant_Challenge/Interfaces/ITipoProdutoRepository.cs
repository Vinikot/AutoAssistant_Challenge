using AutoAssistant_Challenge.Models;

namespace AutoAssistant_Challenge.Interfaces
{
    public interface ITipoProdutoRepository
    {
        ICollection<TipoProdutoModel> GetTipoProdutos();
        TipoProdutoModel GetTipoProduto(int id);
        TipoProdutoModel GetTipoProduto(string nome);
        bool TipoProdutoExists(int produtoId);
        bool CreateTipoProduto(TipoProdutoModel tipoProduto);
        bool UpdateTipoProduto(TipoProdutoModel tipoProduto);
        bool DeleteTipoProduto(TipoProdutoModel tipoProduto);
        bool Save();
    }
}
