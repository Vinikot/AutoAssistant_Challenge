using AutoAssistant_Challenge.Data;
using AutoAssistant_Challenge.Interfaces;
using AutoAssistant_Challenge.Models;
using AutoMapper;

namespace AutoAssistant_Challenge.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PessoaRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreatePessoa(PessoaModel pessoa)
        {
            _context.Add(pessoa);
            return Save();
        }

        public bool DeletePessoa(PessoaModel pessoa)
        {
            _context.Remove(pessoa);
            return Save();
        }

        public PessoaModel GetPessoa(int id)
        {
            return _context.Pessoas.Where(x => x.Id == id).FirstOrDefault();
        }

        public PessoaModel GetPessoa(string nome)
        {
            return _context.Pessoas.Where(x => x.Nome == nome).FirstOrDefault();
        }


        public ICollection<PessoaModel> GetPessoas() 
        {
            return _context.Pessoas.OrderBy(x => x.Id).ToList();
        }

        public bool PessoaExists(int pessoaId)
        {
            return _context.Pessoas.Any(x => x.Id == pessoaId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePessoa(PessoaModel pessoa)
        {
            _context.Update(pessoa);
            return Save();
        }
    }
}
