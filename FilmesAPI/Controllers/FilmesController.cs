using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.DTOs.Filmes;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {

        private readonly FilmesContext _context;
        private readonly IMapper _mapper;

        public FilmesController(FilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Criar([FromBody]CreateFilmeDto dto)
        {
            Filme filme = _mapper.Map<Filme>(dto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var filmes = _context.Filmes;
            return Ok(filmes);
        }

        [HttpGet("{id:int}")]
        public IActionResult BuscarPorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme != null)
            {
                ReadFilmeDto dto = _mapper.Map<ReadFilmeDto>(filme);

                return Ok(dto);
            }

            return NotFound();
        }

        [HttpPut("{id:int}")]
        public IActionResult Atualizar(int id, [FromBody]UpdateFilmeDto dto)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null) return NotFound();

            _mapper.Map(dto, filme);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Excluir(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null) return NotFound();

            _context.Filmes.Remove(filme);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
