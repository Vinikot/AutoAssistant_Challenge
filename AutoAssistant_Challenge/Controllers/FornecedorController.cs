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
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedorController(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<FornecedorModel>))]
        public IActionResult GetFornecedores()
        {
            var fornecedores = _fornecedorRepository.GetFornecedores();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(FornecedorModel))]
        [ProducesResponseType(400)]
        public IActionResult GetFornecedor(int id)
        {
            if (!_fornecedorRepository.FornecedorExists(id))
            {
                return NotFound();
            }

            var fornecedor = _fornecedorRepository.GetFornecedor(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(fornecedor);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateFornecedor([FromBody] FornecedorModel fornecedorCreate)
        {
            if (fornecedorCreate == null)
                return BadRequest(ModelState);

            var fornecedor = _fornecedorRepository.GetFornecedores()
                .Where(c => c.Nome.Trim().ToUpper() == fornecedorCreate.Nome.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (fornecedor != null)
            {
                ModelState.AddModelError("", "Fornecedor already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var fornecedorMap = _mapper.Map<FornecedorModel>(fornecedorCreate);

            if (!_fornecedorRepository.CreateFornecedor(fornecedorMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{fornecedorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateFornecedor(int fornecedorId, [FromBody] FornecedorModel updateFornecedor)
        {
            if (updateFornecedor == null)
                return BadRequest(ModelState);

            if (fornecedorId != updateFornecedor.Id)
                return BadRequest(ModelState);

            if (!_fornecedorRepository.FornecedorExists(fornecedorId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var fornecedorMap = _mapper.Map<FornecedorModel>(updateFornecedor);

            if (!_fornecedorRepository.UpdateFornecedor(fornecedorMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Fornecedor");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{fornecedorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteFornecedor(int fornecedorId)
        {
            if (!_fornecedorRepository.FornecedorExists(fornecedorId))
            {
                return NotFound();
            }

            var fornecedorToDelete = _fornecedorRepository.GetFornecedor(fornecedorId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_fornecedorRepository.DeleteFornecedor(fornecedorToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Pessoa");
            }

            return NoContent();
        }
    }
}
