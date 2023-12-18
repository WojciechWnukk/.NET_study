using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Tytuł może mieć max. 50 znaków.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [UIHint("LongText")]
        public string Description { get; set; }
        [Range(1, 5, ErrorMessage = "Ocena musi być z zakresu od 1 do 5.")]
        [UIHint("Stars")]
        public int Rating { get; set; }
        public string? TrailerLink { get; set; }
        public Genre Genre { get; set; }

    }
}
