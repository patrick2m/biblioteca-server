using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using biblioteca_server.Data;
using biblioteca_server.Data.Models;

namespace biblioteca_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LivrosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivro()
        {
          if (_context.Livro == null)
          {
              return NotFound();
          }
            return await _context.Livro.ToListAsync();
        }

        // GET: api/Livros/matricula/
        [HttpGet("/api/Livros/Matricula/{id}")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivroById(int id)
        {
          if (_context.Livro == null)
          {
              return NotFound();
          }
            var livro = await _context.Livro.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }
            var listaLivros = new List<Livro>() { livro };
            return listaLivros;
        }

        //GET: api/Livros/Nome/
        [HttpGet("/api/Livros/Nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivroByName(string nome)
        {
            if (_context.Livro == null)
            {
                return NotFound();
            }
            var livro = await _context.Livro.FirstOrDefaultAsync(l => l.Nome == nome);

            if (livro == null)
            {
                return new List<Livro>() { };
            }
            var listaLivros = new List<Livro>() { livro };
            return listaLivros;
        }

        //GET: api/Livros/Categoria/
        [HttpGet("/api/Livros/Categoria/{categoria}")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivroByCategory(string categoria)
        {
            if (_context.Livro == null)
            {
                return NotFound();
            }
            var livro = await _context.Livro.Where(l => l.Categoria == categoria).ToListAsync();

            if (livro == null)
            {
                return new List<Livro>() { };
            }

            return livro;
        }

        //GET: api/Livros/Data/
        [HttpGet("/api/Livros/Data/{DataLancamento}")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivroByData(DateTime DataLancamento)
        {
            if (_context.Livro == null)
            {
                return NotFound();
            }
            var livro = await _context.Livro.Where(l => l.DataLancamento == DataLancamento).ToListAsync();

            if (livro == null)
            {
                return new List<Livro>() { };
            }

            return livro;
        }

        //GET: api/Livros/eNacional/
        [HttpGet("/api/Livros/ENacional/{ENacional}")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivroByENacional(bool ENacional)
        {
            if (_context.Livro == null)
            {
                return NotFound();
            }
            var livro = await _context.Livro.Where(l => l.ENacional == ENacional).ToListAsync();

            if (livro == null)
            {
                return new List<Livro>() { };
            }

            return livro;
        }
        [HttpGet("/api/Livros/Autor/{autor}")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivroByAutor(string autor)
        {
            if (_context.Livro == null)
            {
                return NotFound();
            }
            var livro = await _context.Livro.Where(l => l.Autor == autor).ToListAsync();

            if (livro == null)
            {
                return new List<Livro>() { };
            }
            var listaLivros = new List<Livro>() { };
            return listaLivros;
        }

        // PUT: api/Livros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            if (id != livro.Id)
            {
                return BadRequest();
            }

            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST : api/PopularBanco
        [HttpPost("/api/PopularBanco")]
        public async Task<ActionResult<IEnumerable<Livro>>> PostLivros(List<Livro> livros)
        {
            if (livros == null || livros.Count == 0)
            {
                return BadRequest();
            }

            if (_context.Livro == null)
            {
                return NotFound();
            }

            _context.Livro.AddRange(livros);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLivro), new { id = livros[0].Id }, livros);
        }


        // POST: api/Livros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/api/Livros")]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
          if (_context.Livro == null)
          {
              return Problem("Entity set 'biblioteca_serverContext.Livro'  is null.");
          }
            _context.Livro.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivro", new { id = livro.Id }, livro);
        }

        // DELETE: api/Livros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            if (_context.Livro == null)
            {
                return NotFound();
            }
            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETEALL: api/Livros/Todos
        [HttpDelete("/api/Livros/Todos")]
        public async Task<IActionResult> DeleteAllLivros()
        {
            if (_context.Livro == null)
            {
                return NotFound();
            }
            var livros = await _context.Livro.ToListAsync();
            if (livros == null)
            {
                return NotFound();
            }

            _context.Livro.RemoveRange(livros);
            await _context.SaveChangesAsync();

            // Retorna o ID para 1
            var resetIdentitySql = "DELETE FROM sqlite_sequence WHERE name='Livro';";
            await _context.Database.ExecuteSqlRawAsync(resetIdentitySql);

            return NoContent();
        }

        private bool LivroExists(int id)
        {
            return (_context.Livro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
