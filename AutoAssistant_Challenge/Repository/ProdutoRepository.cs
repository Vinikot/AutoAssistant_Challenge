using AutoAssistant_Challenge.Data;
using AutoAssistant_Challenge.Interfaces;
using AutoAssistant_Challenge.Models;
using AutoMapper;

namespace AutoAssistant_Challenge.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProdutoRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateProduto(ProdutoModel produto, int fornecedorId, int compraId)
        {
            _context.Add(produto);
            return Save();
        }

        public bool DeleteProduto(ProdutoModel produto)
        {
            _context.Remove(produto);
            return Save();
        }

        public ProdutoModel GetProduto(int id)
        {
            return _context.Produtos.Where(x => x.Id == id).FirstOrDefault();
        }

        public ProdutoModel GetProduto(string nome)
        {
            return _context.Produtos.Where(x => x.Nome == nome).FirstOrDefault();
        }

        public ICollection<ProdutoModel> GetProdutos() 
        {
            return _context.Produtos.OrderBy(x => x.Id).ToList();
        }

        public bool ProdutoExists(int produtoId)
        {
            return _context.Produtos.Any(x => x.Id == produtoId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProduto(ProdutoModel produto, int fornecedorId, int compraId)
        {
            _context.Update(produto);
            return Save();
        }
    }
}
