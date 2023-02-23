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
        public void Criar([FromBody]Filme filme)
        {
            filme.Id = id;
            id++;
            filmes.Add(filme);
        }

        [HttpGet]
        public IEnumerable<Filme> Listar()
        {
            return filmes;
        }

        [HttpGet("{id:int}")]
        public Filme BuscarPorId(int id)
        {
            var filme = filmes.FirstOrDefault(f => f.Id == id);

            return filme;
        }
    }
}
