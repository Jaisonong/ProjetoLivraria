using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriandoPrimeiraAPI.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public double Preco { get; set; }
        public int QtdeEmEstoque { get; set; }
        public EnumGenero Genero { get; set; }
    }
}