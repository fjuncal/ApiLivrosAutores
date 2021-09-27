using System.Collections.Generic;

namespace ApiLivros.Repository.Autor
{
    public interface IAutorRepository
    {
        List<AutorLivroDTO> GetAll();
        void CadastrarAutor(AutorDTO autor);
        AutorLivroDTO GetAutorComLivro(int autorId);
        void RemoverAutor(int id);
        Comum.Models.Autor BuscarAutor(int id);
        void EditarAutor(int id, Comum.Models.Autor autor);

        public void EditarAutorComLivro(int id, AutorDTO autor);
    }
}