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
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IMapper _mapper;

        public CompraController(ICompraRepository compraRepository, IMapper mapper)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<CompraModel>))]
        public IActionResult GetCompras()
        {
            var compras = _compraRepository.GetCompras();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(compras);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CompraModel))]
        [ProducesResponseType(400)]
        public IActionResult GetCompra(int id)
        {
            if (!_compraRepository.CompraExists(id))
            {
                return NotFound();
            }

            var compra = _compraRepository.GetCompra(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(compra);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCompra([FromBody] CompraModel compraCreate)
        {
            if (compraCreate == null)
                return BadRequest(ModelState);

            var compra = _compraRepository.GetCompras()
                .Where(c => c.CodigoCompra == compraCreate.CodigoCompra)
                .FirstOrDefault();

            if (compra != null)
            {
                ModelState.AddModelError("", "Compra already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var compraMap = _mapper.Map<CompraModel>(compraCreate);

            if (!_compraRepository.CreateCompra(compraMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{compraId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCompra(int compraId, [FromBody] CompraModel updateCompra)
        {
            if (updateCompra == null)
                return BadRequest(ModelState);

            if (compraId != updateCompra.Id)
                return BadRequest(ModelState);

            if (!_compraRepository.CompraExists(compraId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var compraMap = _mapper.Map<CompraModel>(updateCompra);

            if (!_compraRepository.CompraExists(compraId))
            {
                ModelState.AddModelError("", "Something went wrong updating Compra");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{compraId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCompra(int compraId)
        {
            if (!_compraRepository.CompraExists(compraId))
            {
                return NotFound();
            }

            var compraToDelete = _compraRepository.GetCompra(compraId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_compraRepository.DeleteCompra(compraToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Compra");
            }

            return NoContent();
        }
    }
}
