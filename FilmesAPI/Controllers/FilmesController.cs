using FilmesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult Criar([FromBody]Filme filme)
        {
            filme.Id = id;
            id++;
            filmes.Add(filme);

            return CreatedAtAction(nameof(BuscarPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(filmes);
        }

        [HttpGet("{id:int}")]
        public IActionResult BuscarPorId(int id)
        {
            var filme = filmes.FirstOrDefault(f => f.Id == id);

            if (filme != null) return Ok(filme);

            return NotFound();
        }
    }
}
