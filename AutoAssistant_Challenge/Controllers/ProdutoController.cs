using AutoAssistant_Challenge.Interfaces;
using AutoAssistant_Challenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoAssistant_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<ProdutoModel>))]
        public IActionResult GetProdutos() 
        {
            var produtos = _produtoRepository.GetProdutos();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(produtos);
        }
    }
}
