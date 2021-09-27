using System;
using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;

namespace Comum.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Isbn { get; set; }
        public DateTime Ano { get; set; }
        
        public IList<AutorLivro> AutorLivroList { get; set; }
        
        /*[JsonIgnore]
        public List<Autor> Autores { get; set; }*/
    }
}