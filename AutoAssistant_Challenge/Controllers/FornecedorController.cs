using AutoAssistant_Challenge.Interfaces;
using AutoAssistant_Challenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoAssistant_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
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
    }
}
