using System.ComponentModel.DataAnnotations;

namespace APILIVROS.Models;

public class Book
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title can't be empty")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Gender can't be empty")]
    [StringLength(50, ErrorMessage = "Gender accept till 50 characters")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "Author can't be empty")]
    public string Author { get; set; }

    [Required(ErrorMessage = "Pages can't be empty")]
    public string Pages { get; set; }

    [Required(ErrorMessage = "Publishing House can't be empty")]
    public string PublishingHouse { get; set; }
}
