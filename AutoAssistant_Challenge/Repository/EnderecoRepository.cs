using AutoAssistant_Challenge.Data;
using AutoAssistant_Challenge.Interfaces;
using AutoAssistant_Challenge.Models;
using AutoMapper;
using System.Diagnostics.Metrics;

namespace AutoAssistant_Challenge.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EnderecoRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateEndereco(EnderecoModel endereco)
        {
            _context.Add(endereco);
            return Save();
        }

        public bool DeleteEndereco(EnderecoModel endereco)
        {
            _context.Remove(endereco);
            return Save();
        }

        public bool EnderecoExists(int enderecoId)
        {
            return _context.Enderecos.Any(x => x.Id == enderecoId);
        }

        public EnderecoModel GetEndereco(int id)
        {
            return _context.Enderecos.Where(x => x.Id == id).FirstOrDefault();
        }

        public ICollection<EnderecoModel> GetEnderecos() 
        {
            return _context.Enderecos.OrderBy(x => x.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEndereco(EnderecoModel endereco)
        {
            _context.Update(endereco);
            return Save();
        }
    }
}
