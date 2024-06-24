using System.ComponentModel.DataAnnotations;

namespace T3_Jimenez_Diego.Models
{
    public class Libro
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "El titulo es obligatorio")]
        public string titulo { get; set; }
        [Required(ErrorMessage = "El autor es obligatorio")]
        public string autor { get; set;}
        [Required(ErrorMessage = "El tema es obligatorio")]
        public string tema { get; set;}
        [Required(ErrorMessage = "La editorial es obligatoria")]
        public string editorial { get; set;}
        [Required(ErrorMessage = "El año de publicación es obligatorio")]
        [Range(1900,3000, ErrorMessage = "El año de publicación no es válido, debe ser entre 1900 a 3000")]
        public string anioPublicacion { get; set;}
        [Required(ErrorMessage = "La cantidad de paginas son obligatorias")]
        [Range(10,1000, ErrorMessage = ("La cantidad de páginas no es válida, debe ser entre 10 a 1000"))]
        public int paginas { get; set; }
        [Required(ErrorMessage = "La categoria es obligatoria")]
        public string categoria { get; set;}
    }
}
