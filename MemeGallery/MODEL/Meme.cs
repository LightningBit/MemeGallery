using System.ComponentModel.DataAnnotations;

namespace MemeGallery.Model
{
    public class Meme
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Only 2-100 characters allowed")]
        public string? Caption { get; set; }

        [Required]
        public string? Category { get; set; }

        public int? Rank { get; set; }

        [Required]
        public string? BlobURL { get; set; }

        public int? UpVote { get; set; }

        [Required]
        public bool Other { get; set; }

        public string? SupportingLinks { get; set; }









      

    }
}
