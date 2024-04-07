using AutoAssistant_Challenge.Interfaces;
using AutoAssistant_Challenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoAssistant_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
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
    }
}
