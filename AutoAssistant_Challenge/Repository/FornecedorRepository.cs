using AutoAssistant_Challenge.Data;
using AutoAssistant_Challenge.Interfaces;
using AutoAssistant_Challenge.Models;
using AutoMapper;
using System.Diagnostics.Metrics;

namespace AutoAssistant_Challenge.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FornecedorRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateFornecedor(FornecedorModel fornecedor)
        {
            _context.Add(fornecedor);
            return Save();
        }

        public bool DeleteFornecedor(FornecedorModel fornecedor)
        {
            _context.Remove(fornecedor);
            return Save();
        }

        public bool FornecedorExists(int fornecedorId)
        {
            return _context.Fornecedores.Any(x => x.Id == fornecedorId);
        }

        public FornecedorModel GetFornecedor(int id)
        {
            return _context.Fornecedores.Where(x => x.Id == id).FirstOrDefault();
        }

        public FornecedorModel GetFornecedor(string nome)
        {
            return _context.Fornecedores.Where(x => x.Nome == nome).FirstOrDefault();
        }

        public ICollection<FornecedorModel> GetFornecedores() 
        {
            return _context.Fornecedores.OrderBy(x => x.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateFornecedor(FornecedorModel fornecedor)
        {
            _context.Update(fornecedor);
            return Save();
        }
    }
}
