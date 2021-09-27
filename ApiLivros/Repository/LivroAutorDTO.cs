using System;
using System.Collections.Generic;

namespace ApiLivros.Repository
{
    public class LivroAutorDTO
    {

            public int Id { get; set; }
            public string Titulo { get; set; }
            public string Isbn { get; set; }
            public DateTime Ano { get; set; }
        
            public List<string> AutorsNome { get; set; }
        
    }
}