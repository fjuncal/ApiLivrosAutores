using System.Linq;
using ApiLivros.Repository;
using Comum.Models;
using Comum.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiLivros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivroController(ApiDbContext apiDbContext, ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        
        [HttpGet]
        public IActionResult ObterLivros()
        {
            var livros = _livroRepository.GetAll();
            return Ok(livros);
        }
        
        [HttpPost("adicionar-autor-livro")]
        public IActionResult SalvarLivroEAutor([FromBody]LivroDTO livro)
        {
            _livroRepository.CadastrarLivroComAutor(livro);
            return Ok(livro);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remover([FromRoute] int id)
        {
            _livroRepository.RemoverLivro(id);
            return Ok();

        }

        [HttpGet("{id}")]
        public IActionResult BuscarLivro([FromRoute] int id)
        {
            
            var livroComAutor = _livroRepository.BuscarLivroComAutor(id);
            if (livroComAutor == null)
            {
                return BadRequest();
            }
            return Ok(livroComAutor);
        }
        
        [HttpPut("{id}")]
        public IActionResult EditarLivro([FromRoute] int id, [FromBody]LivroDTO livro)
        {
            
            _livroRepository.EditarLivroComAutor(id, livro);
            return NoContent();
        }
        
    }
}