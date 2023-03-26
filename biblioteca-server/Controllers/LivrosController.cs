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
        [HttpGet("/Livros/Matricula/{id}")]
        public async Task<ActionResult<Livro>> GetLivroById(int id)
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

            return livro;
        }

        //GET: api/Livros/Nome/
        [HttpGet("/Livros/Nome/{nome}")]
        public async Task<ActionResult<Livro>> GetLivroByName(string nome)
        {
            if (_context.Livro == null)
            {
                return NotFound();
            }
            var livro = await _context.Livro.FirstOrDefaultAsync(l => l.Nome == nome);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        //GET: api/Livros/Categoria/
        [HttpGet("/Livros/Categoria/{categoria}")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivroByCategory(string categoria)
        {
            if (_context.Livro == null)
            {
                return NotFound();
            }
            var livro = await _context.Livro.Where(l => l.Categoria == categoria).ToListAsync();

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        //GET: api/Livros/data/
        [HttpGet("/Livros/Data/{DataLancamento}")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivroByData(DateTime DataLancamento)
        {
            if (_context.Livro == null)
            {
                return NotFound();
            }
            var livro = await _context.Livro.Where(l => l.DataLancamento == DataLancamento).ToListAsync();

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }


        //GET: api/Livros/eNacional/
        [HttpGet("/Livros/eNacional/{eNacional}")]
        public async Task<ActionResult<Livro>> GetLivroByENacional(bool ENacional)
        {
            if (_context.Livro == null)
            {
                return NotFound();
            }
            var livro = await _context.Livro.FindAsync(ENacional);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
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

        // POST: api/Livros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
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

        private bool LivroExists(int id)
        {
            return (_context.Livro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
