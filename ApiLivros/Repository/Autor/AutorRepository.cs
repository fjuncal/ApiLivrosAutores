using System.Collections.Generic;
using System.Linq;
using Comum.Models;
using Comum.Repository;

namespace ApiLivros.Repository.Autor
{
    public class AutorRepository : IAutorRepository
    {
        private readonly ApiDbContext _apiDbContext;

        public AutorRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }
        
        public List<AutorLivroDTO> GetAll()
        {
            var autores = _apiDbContext.Autor.Select(n => new AutorLivroDTO()
            {
                Id = n.Id,
                Nome = n.Nome,
                Email = n.Email,
                Sobrenome = n.Sobrenome,
                DataNascimento = n.DataNascimento,
                LivrosNome = n.AutorLivroList.Select(nLivroAutor => nLivroAutor.Livro.Titulo).ToList()
            }).ToList();
            return autores;
        }

        public void CadastrarAutor(AutorDTO autor)
        {
            var _autor = new Comum.Models.Autor()
            {
                Nome = autor.Nome,
                Email = autor.Email,
                Sobrenome = autor.Sobrenome,
                DataNascimento = autor.DataNascimento
            };
            _apiDbContext.Autor.Add(_autor);
            _apiDbContext.SaveChanges();
        }

        public void RemoverAutor(int id)
        {
            var autorRemover = _apiDbContext.Autor.Find(id);
            _apiDbContext.Autor.Remove(autorRemover);
            _apiDbContext.SaveChanges();
        }

        public Comum.Models.Autor BuscarAutor(int id)
        {
            var autor = _apiDbContext.Autor.Find(id);
            return autor;
        }

        public void EditarAutor(int id, Comum.Models.Autor autor)
        {
            var autorEditar = _apiDbContext.Autor.Find(id);
            autorEditar.Nome = autor.Nome;
            autorEditar.Email = autor.Email;
            autorEditar.Sobrenome = autor.Sobrenome;
            autorEditar.DataNascimento = autor.DataNascimento;
            _apiDbContext.Autor.Update(autorEditar);
            _apiDbContext.SaveChanges();
        }

        public AutorLivroDTO GetAutorComLivro(int autorId)
        {
            var _autor = _apiDbContext.Autor.Where(n => n.Id == autorId).Select(n => new AutorLivroDTO()
            {
                Nome = n.Nome,
                Email = n.Email,
                DataNascimento = n.DataNascimento,
                Sobrenome = n.Sobrenome,
                LivrosNome = n.AutorLivroList.Select(n => n.Livro.Titulo).ToList()
                
            }).FirstOrDefault();
            return _autor;
        }
        
        public void EditarAutorComLivro(int id, AutorDTO autor)
        {
            var autorEditar = _apiDbContext.Autor.Find(id);
            autorEditar.Nome = autor.Nome;
            autorEditar.Email = autor.Email;
            autorEditar.Sobrenome = autor.Sobrenome;
            autorEditar.DataNascimento = autor.DataNascimento;
            _apiDbContext.Autor.Update(autorEditar);
            _apiDbContext.SaveChanges();

            foreach (var idTable in autor.LivrosId)
            {
                var _livro_autor = new AutorLivro()
                {
                    AutorId  = autorEditar.Id,
                    LivroId = idTable
                };
                _apiDbContext.AutorLivro.Update(_livro_autor);
                _apiDbContext.SaveChanges();
            }
        }
    }
}