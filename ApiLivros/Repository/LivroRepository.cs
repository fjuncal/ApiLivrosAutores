using System.Collections.Generic;
using System.Linq;
using Comum.Models;
using Comum.Repository;

namespace ApiLivros.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ApiDbContext _apiDbContext;

        public LivroRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }
        
        public List<LivroAutorDTO> GetAll()
        {
            var livros = _apiDbContext.Livro.Select(n => new LivroAutorDTO()
            {
                Id = n.Id,
                Titulo = n.Titulo,
                Ano = n.Ano,
                Isbn = n.Isbn,
                AutorsNome = n.AutorLivroList.Select(nLivroAutor => nLivroAutor.Autor.Nome).ToList()

            }).ToList();
            return livros;
        }

        public void CadastrarLivro(Livro livro)
        {
            _apiDbContext.Livro.Add(livro);
            _apiDbContext.SaveChanges();
        }
        
        public void CadastrarLivroComAutor(LivroDTO livro)
        {
            var _livro = new Livro()
            {
                Titulo = livro.Titulo,
                Ano = livro.Ano,
                Isbn = livro.Isbn
            };
            _apiDbContext.Livro.Add(_livro);
            _apiDbContext.SaveChanges();

            foreach (var id in livro.AutorsId)
            {
                var _livro_autor = new AutorLivro()
                {
                    LivroId = _livro.Id,
                    AutorId = id
                };
                _apiDbContext.AutorLivro.Add(_livro_autor);
                _apiDbContext.SaveChanges();
            }
        }

        public void RemoverLivro(int id)
        {
            var livro = _apiDbContext.Livro.Find(id);
            _apiDbContext.Livro.Remove(livro);
            _apiDbContext.SaveChanges();
        }

        public Livro BuscarLivro(int id)
        {
            var livro = _apiDbContext.Livro.Find(id);
            return livro;
        }
        
        public LivroAutorDTO BuscarLivroComAutor(int id)
        {
            var livroComAutor = _apiDbContext.Livro.Where(n => n.Id == id).Select(livro => new LivroAutorDTO()
            {
                Titulo = livro.Titulo,
                Ano = livro.Ano,
                Isbn = livro.Isbn,
                AutorsNome = livro.AutorLivroList.Select(n => n.Autor.Nome).ToList()
            }).FirstOrDefault();
            return livroComAutor;
        }

        public void EditarLivro(int id, Livro livro)
        {
            var livroEditar = _apiDbContext.Livro.Find(id);
            livroEditar.Titulo = livro.Titulo;
            livroEditar.Ano = livro.Ano;
            livroEditar.Isbn = livro.Isbn;
            _apiDbContext.Livro.Update(livroEditar);
            _apiDbContext.SaveChanges();
        }

        public void EditarLivroComAutor(int id, LivroDTO livro)
        {
            var livroEditar = _apiDbContext.Livro.Find(id);
            livroEditar.Titulo = livro.Titulo;
            livroEditar.Ano = livro.Ano;
            livroEditar.Isbn = livro.Isbn;
            _apiDbContext.Livro.Update(livroEditar);
            _apiDbContext.SaveChanges();

            foreach (var idTable in livro.AutorsId)
            {
                var _livro_autor = new AutorLivro()
                {
                    LivroId = livroEditar.Id,
                    AutorId = idTable
                };
                _apiDbContext.AutorLivro.Update(_livro_autor);
                _apiDbContext.SaveChanges();
            }
        }
        
    }
}