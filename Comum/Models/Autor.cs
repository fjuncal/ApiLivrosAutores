using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Comum.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }

        public IList<AutorLivro> AutorLivroList { get; set; }
        
        /*[JsonIgnore]
        public List<Livro> Livros { get; set; }*/
    }
}