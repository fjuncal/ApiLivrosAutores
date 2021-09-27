using System.Collections.Generic;
using Comum.Models;

namespace ApiLivros.Repository
{
    public interface ILivroRepository
    {
        List<LivroAutorDTO> GetAll();
        void CadastrarLivro(Livro livro);
        void CadastrarLivroComAutor(LivroDTO livro);
        void RemoverLivro(int id);
        Livro BuscarLivro(int id);
        LivroAutorDTO BuscarLivroComAutor(int id);
        void EditarLivro(int id, Livro livro);
        void EditarLivroComAutor(int id, LivroDTO livro);
    }
}