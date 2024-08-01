using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriandoPrimeiraAPI.Context;
using CriandoPrimeiraAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace CriandoPrimeiraAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class LivroController : ControllerBase
    {
        private readonly GerenciamentoLivraria _context;

        public LivroController(GerenciamentoLivraria context)
        {
            _context = context;
        }

        [HttpPost("AdicionarLivro")]
        public IActionResult AdicionarLivro(Livro novoLivro, EnumGenero genero)
        {
            
            novoLivro.Genero = genero;
            //Adiciona um novo livro ao banco de dados
            _context.Livros.Add(novoLivro);
            _context.SaveChanges();

            return Ok(novoLivro);
        }
        [HttpGet("ObterPorGenero")]
        public IActionResult ObterPorGenero(EnumGenero genero)
        {
            //Retorna os livros por genero
            var obterLivro = _context.Livros.Where(x => x.Genero == genero);
            return Ok(obterLivro);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Deleta o ID do banco de dados
            var livroBanco = _context.Livros.Find(id);
            if (livroBanco == null)
            {
                return NotFound();
            }
            //Remove e salva as alterações
            _context.Remove(livroBanco);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("AtualizarLivro")]
        public IActionResult AtualizarLivro(int id, Livro livro, EnumGenero genero)
        {
            var livroBanco = _context.Livros.Find(id);

            if (livroBanco == null)
            {
                return NotFound();
            }
            //Atualiza informações do banco de dados
            livroBanco.Autor = livro.Autor;
            livroBanco.Titulo = livro.Titulo;
            livroBanco.Preco = livro.Preco;
            livroBanco.QtdeEmEstoque = livro.QtdeEmEstoque;
            livroBanco.Genero = genero;

            //Altera os dados e salva no banco
            _context.Update(livroBanco);
            _context.SaveChanges();

            return Ok(livroBanco);
        }
        
        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            //Retorna lista de livro buscando pelo titulo semelhante
            var livros = _context.Livros.Where(x => x.Titulo.Contains(titulo)).ToList();

            return Ok(livros);
        }


    }
}