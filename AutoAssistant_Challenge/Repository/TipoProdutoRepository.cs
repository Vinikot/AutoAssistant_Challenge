using AutoAssistant_Challenge.Data;
using AutoAssistant_Challenge.Interfaces;
using AutoAssistant_Challenge.Models;
using AutoMapper;
using System.Diagnostics.Metrics;

namespace AutoAssistant_Challenge.Repository
{
    public class TipoProdutoRepository : ITipoProdutoRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TipoProdutoRepository(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateTipoProduto(TipoProdutoModel tipoProduto)
        {
            _context.Add(tipoProduto);
            return Save();
        }

        public bool DeleteTipoProduto(TipoProdutoModel tipoProduto)
        {
            _context.Remove(tipoProduto);
            return Save();
        }

        public TipoProdutoModel GetTipoProduto(int id)
        {
            return _context.TipoProdutos.Where(x => x.Id == id).FirstOrDefault();
        }

        public TipoProdutoModel GetTipoProduto(string nome)
        {
            return _context.TipoProdutos.Where(x => x.Nome == nome).FirstOrDefault();
        }

        public ICollection<TipoProdutoModel> GetTipoProdutos()
        {
            return _context.TipoProdutos.OrderBy(x => x.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TipoProdutoExists(int produtoId)
        {
            return _context.TipoProdutos.Any(x => x.Id == produtoId);
        }

        public bool UpdateTipoProduto(TipoProdutoModel tipoProduto)
        {
            _context.Update(tipoProduto);
            return Save();
        }
    }
}
