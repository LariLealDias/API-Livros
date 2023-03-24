using APILIVROS.Data;
using APILIVROS.Models;
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpGet]
    public IEnumerable<Book> GetAllBooks([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Books.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = _context.Books.FirstOrDefault(book => book.Id == id);
        if (book == null) return NotFound();
        return Ok(book);
    }


    [HttpPatch("{id}")]
    public IActionResult UpdateBookById(int id, JsonPatchDocument<Book> patch)
    {
        var book = _context.Books.FirstOrDefault(book => book.Id == id);
        if (book == null) return NotFound();

        patch.ApplyTo(book, ModelState);

        if (!TryValidateModel(book))
        {
            return ValidationProblem(ModelState);
        }
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _context.Books.FirstOrDefault(book => book.Id == id);
        if (book == null) return NotFound();
        _context.Remove(book);
        _context.SaveChanges();
        return NoContent();
    }



}
