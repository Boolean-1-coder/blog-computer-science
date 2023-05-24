using BlogComputerScience.Models.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogComputerScience.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio!")]
        [StringLength(100, ErrorMessage = "Il campo titolo può essere lungo al massimo 100 caratteri")]
        [MoreThanThreeWords(ErrorMessage = "Il campo titolo deve contenere almeno 3 parole!")]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Il campo descrizione è obbligatorio!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Il campo URL dell'immagine è obbligatorio")]
        [Url(ErrorMessage = "L'URL inserito non è un url valido!")]
        [StringLength(300, ErrorMessage = "Il campo URL immagine può contenere al massimo 300 caratteri")]
        public string Image { get; set; }

        public Article()
        {

        }

        public Article(string title, string description, string image)
        {
            Title = title;
            Description = description;
            Image = image;
        }
    }
}
