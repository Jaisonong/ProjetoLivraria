using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriandoPrimeiraAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CriandoPrimeiraAPI.Context
{
    public class GerenciamentoLivraria : DbContext
    { 
        public GerenciamentoLivraria(DbContextOptions<GerenciamentoLivraria> options) : base (options)
        {

        }

        public DbSet<Livro> Livros { get; set; }
    }
}