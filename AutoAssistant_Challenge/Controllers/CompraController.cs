using AutoAssistant_Challenge.Interfaces;
using AutoAssistant_Challenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoAssistant_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepository _compraRepository;

        public CompraController(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
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
    }
}
