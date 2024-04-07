using AutoAssistant_Challenge.Interfaces;
using AutoAssistant_Challenge.Models;
using AutoAssistant_Challenge.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoAssistant_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public EnderecoController(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<EnderecoModel>))]
        public IActionResult GetEnderecos()
        {
            var enderecos = _enderecoRepository.GetEnderecos();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(EnderecoModel))]
        [ProducesResponseType(400)]
        public IActionResult GetEndereco(int id)
        {
            if (!_enderecoRepository.EnderecoExists(id))
            {
                return NotFound();
            }

            var endereco = _enderecoRepository.GetEndereco(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(endereco);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEndereco([FromBody] EnderecoModel enderecoCreate)
        {
            if (enderecoCreate == null)
                return BadRequest(ModelState);

            var endereco = _enderecoRepository.GetEnderecos()
                .Where(c => c.Cep.Trim().ToUpper() == enderecoCreate.Cep.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (endereco != null)
            {
                ModelState.AddModelError("", "Endereco already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var enderecoMap = _mapper.Map<EnderecoModel>(enderecoCreate);

            if (!_enderecoRepository.CreateEndereco(enderecoMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{enderecoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEndereco(int enderecoId, [FromBody] EnderecoModel updateEndereco)
        {
            if (updateEndereco == null)
                return BadRequest(ModelState);

            if (enderecoId != updateEndereco.Id)
                return BadRequest(ModelState);

            if (!_enderecoRepository.EnderecoExists(enderecoId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var enderecoMap = _mapper.Map<EnderecoModel>(updateEndereco);

            if (!_enderecoRepository.EnderecoExists(enderecoId))
            {
                ModelState.AddModelError("", "Something went wrong updating Endereco");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{enderecoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteFornecedor(int enderecoId)
        {
            if (!_enderecoRepository.EnderecoExists(enderecoId))
            {
                return NotFound();
            }

            var enderecoToDelete = _enderecoRepository.GetEndereco(enderecoId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_enderecoRepository.DeleteEndereco(enderecoToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Endereco");
            }

            return NoContent();
        }
    }
}
