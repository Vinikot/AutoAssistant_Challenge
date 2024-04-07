using AutoAssistant_Challenge.Interfaces;
using AutoAssistant_Challenge.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AutoAssistant_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProdutoController : ControllerBase
    {
        private readonly ITipoProdutoRepository _tipoProdutoRepository;
        private readonly IMapper _mapper;

        public TipoProdutoController(ITipoProdutoRepository tipoProdutoRepository, IMapper mapper)
        {
            _tipoProdutoRepository = tipoProdutoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<TipoProdutoModel>))]
        public IActionResult GetTipoProdutos()
        {
            var tipoProdutos = _tipoProdutoRepository.GetTipoProdutos();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tipoProdutos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TipoProdutoModel))]
        [ProducesResponseType(400)]
        public IActionResult GetTipoProduto(int id)
        {
            if (!_tipoProdutoRepository.TipoProdutoExists(id))
            {
                return NotFound();
            }
            
            var tipoProduto = _tipoProdutoRepository.GetTipoProduto(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tipoProduto);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTipoProduto([FromBody] TipoProdutoModel tipoProdutoCreate)
        {
            if (tipoProdutoCreate == null)
                return BadRequest(ModelState);

            var tipoProduto = _tipoProdutoRepository.GetTipoProdutos()
                .Where(c => c.Nome.Trim().ToUpper() == tipoProdutoCreate.Nome.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (tipoProduto != null)
            {
                ModelState.AddModelError("", "Tipo-Produto already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tipoProdutoMap = _mapper.Map<TipoProdutoModel>(tipoProdutoCreate);

            if (!_tipoProdutoRepository.CreateTipoProduto(tipoProdutoMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{tipoProdutoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTipoProduto(int tipoProdutoId, [FromBody] TipoProdutoModel updateTipoProduto)
        {
            if (updateTipoProduto == null)
                return BadRequest(ModelState);

            if (tipoProdutoId != updateTipoProduto.Id)
                return BadRequest(ModelState);

            if (!_tipoProdutoRepository.TipoProdutoExists(tipoProdutoId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var tipoProdutoMap = _mapper.Map<TipoProdutoModel>(updateTipoProduto);

            if (!_tipoProdutoRepository.UpdateTipoProduto(tipoProdutoMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{tipoProdutoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTipoProduto(int tipoProdutoId)
        {
            if (!_tipoProdutoRepository.TipoProdutoExists(tipoProdutoId))
            {
                return NotFound();
            }

            var tipoProdutoToDelete = _tipoProdutoRepository.GetTipoProduto(tipoProdutoId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_tipoProdutoRepository.DeleteTipoProduto(tipoProdutoToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Tipo-Produto");
            }

            return NoContent();
        }
    }
}
