using System.ComponentModel.DataAnnotations;

namespace APILIVROS.Data.Dtos;

public class ReadBookDto
{
    public string Title { get; set; }
    public string Gender { get; set; }
    public string Author { get; set; }
    public string Pages { get; set; }
    public string PublishingHouse { get; set; }
    public DateTime? GetDateTime { get;} = DateTime.Now;
}
