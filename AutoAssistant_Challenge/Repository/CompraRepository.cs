using AutoAssistant_Challenge.Data;
using AutoAssistant_Challenge.Interfaces;
using AutoAssistant_Challenge.Models;
using AutoMapper;
using System.Diagnostics.Metrics;

namespace AutoAssistant_Challenge.Repository
{
    public class CompraRepository : ICompraRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CompraRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CompraExists(int compraId)
        {
            return _context.Compras.Any(x => x.Id == compraId);
        }

        public bool CreateCompra(CompraModel compra)
        {
            _context.Add(compra);
            return Save();
        }

        public bool DeleteCompra(CompraModel compra)
        {
            _context.Remove(compra);
            return Save();
        }

        public CompraModel GetCompra(int id)
        {
            return _context.Compras.Where(x => x.Id == id).FirstOrDefault();
        }

        public ICollection<CompraModel> GetCompras()
        {
            return _context.Compras.OrderBy(x => x.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCompra(CompraModel compra)
        {
            _context.Update(compra);
            return Save();
        }
    }
}
