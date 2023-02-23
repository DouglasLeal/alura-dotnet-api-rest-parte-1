﻿using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {

        private FilmesContext _context;

        public FilmesController(FilmesContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar([FromBody]Filme filme)
        {
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

            if (filme != null) return Ok(filme);

            return NotFound();
        }
    }
}
