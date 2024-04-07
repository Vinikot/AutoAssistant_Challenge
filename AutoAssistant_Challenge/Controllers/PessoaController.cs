using AutoAssistant_Challenge.Dto;
using AutoAssistant_Challenge.Interfaces;
using AutoAssistant_Challenge.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AutoAssistant_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<PessoaModel>))]
        public IActionResult GetPessoas() 
        {
            var pessoas = _mapper.Map<List<PessoaDto>>(_pessoaRepository.GetPessoas());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PessoaModel))]
        [ProducesResponseType(400)]
        public IActionResult GetTipoProduto(int id)
        {
            if (!_pessoaRepository.PessoaExists(id))
            {
                return NotFound();
            }

            var pessoa = _pessoaRepository.GetPessoa(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pessoa);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTipoProduto([FromBody] PessoaModel pessoaCreate)
        {
            if (pessoaCreate == null)
                return BadRequest(ModelState);

            var pessoa = _pessoaRepository.GetPessoas()
                .Where(c => c.Nome.Trim().ToUpper() == pessoaCreate.Nome.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (pessoa != null)
            {
                ModelState.AddModelError("", "Pessoa already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pessoaMap = _mapper.Map<PessoaModel>(pessoaCreate);

            if (!_pessoaRepository.CreatePessoa(pessoaMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{pessoaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTipoProduto(int pessoaId, [FromBody] PessoaModel updatePessoa)
        {
            if (updatePessoa == null)
                return BadRequest(ModelState);

            if (pessoaId != updatePessoa.Id)
                return BadRequest(ModelState);

            if (!_pessoaRepository.PessoaExists(pessoaId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var pessoaMap = _mapper.Map<PessoaModel>(updatePessoa);

            if (!_pessoaRepository.UpdatePessoa(pessoaMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Pessoa");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{pessoaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTipoProduto(int pessoaId)
        {
            if (!_pessoaRepository.PessoaExists(pessoaId))
            {
                return NotFound();
            }

            var pessoaToDelete = _pessoaRepository.GetPessoa(pessoaId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_pessoaRepository.DeletePessoa(pessoaToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Pessoa");
            }

            return NoContent();
        }
    }
}
