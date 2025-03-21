using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [StringLength(100)]
        public required string Genre { get; set; }
        
        public string? Description { get; set; }

        [Required]
        [Range(0.01, 1000)]
        public required decimal Price { get; set; }

        public required DateTime ReleaseDate { get; set; }
    }
}
