using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FilmesAPI.DTOs.Filmes
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Título")]
        public string? Titulo { get; set; }

        public string? Diretor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Gênero")]
        public string? Genero { get; set; }

        [DisplayName("Duração")]
        [Range(30, 600, ErrorMessage = "O campo {0} deve ter no mínimo {1} e no máximo {2} minutos.")]
        public int Duracao { get; set; }
    }
}
