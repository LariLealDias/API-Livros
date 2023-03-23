using APILIVROS.Data;
using APILIVROS.Models;
using Microsoft.AspNetCore.Mvc;

namespace APILIVROS.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    public BookController(BookContext contex)
    {
        _context = contex;
    }
    private BookContext _context;

    [HttpPost]
    public IActionResult CreateBook([FromBody] Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return CreatedAtAction(nameof(CreateBook), new { id = book.Id }, book);
    }
}
