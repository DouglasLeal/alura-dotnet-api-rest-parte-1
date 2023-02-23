using AutoMapper;
using FilmesAPI.DTOs.Filmes;
using FilmesAPI.Models;

namespace FilmesAPI.AutoMapper
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
