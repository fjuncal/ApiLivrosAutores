using System;
using System.Collections.Generic;

namespace ApiLivros.Repository.Autor
{
    public class AutorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        
        public List<int> LivrosId { get; set; }
    }
}