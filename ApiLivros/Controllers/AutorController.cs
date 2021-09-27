using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using ApiLivros.Repository.Autor;
using Comum.Models;
using Comum.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiLivros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }


        [HttpGet]
        public IActionResult ObterAutores()
        {
            var autores = _autorRepository.GetAll();
            return Ok(autores);
        }

        [HttpPost]
        public IActionResult Salvar(AutorDTO autor)
        {
            _autorRepository.CadastrarAutor(autor);
            return Ok(autor);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remover([FromRoute] int id)
        {
            _autorRepository.RemoverAutor(id);
            return Ok();

        }
        
        [HttpGet("get-autor-com-livro/{id}")]
        public IActionResult BuscarAutorComLivro([FromRoute] int id)
        {
            var response = _autorRepository.GetAutorComLivro(id);

            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        
        [HttpPut("{id}")]
        public IActionResult EditarAutor([FromRoute] int id, [FromBody]AutorDTO autor)
        {
            _autorRepository.EditarAutorComLivro(id, autor);

            return NoContent();
        }
    }
}