using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

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
