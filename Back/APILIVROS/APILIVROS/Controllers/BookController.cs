using APILIVROS.Data;
using APILIVROS.Data.Dtos;
using APILIVROS.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APILIVROS.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    public BookController(BookContext contex, IMapper mapper)
    {
        _context = contex;
        _mapper = mapper;
    }
    private BookContext _context;
    private IMapper _mapper;

    [HttpPost]
    public IActionResult CreateBook([FromBody] CreateBookDto bookDto)
    {
        Book book = _mapper.Map<Book>(bookDto);
        _context.Books.Add(book);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }

    [HttpGet]
    public IEnumerable<ReadBookDto> GetAllBooks([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadBookDto>>(_context.Books.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = _context.Books.FirstOrDefault(book => book.Id == id);
        if (book == null) return NotFound();

        var bookDto = _mapper.Map<ReadBookDto>(book);
        return Ok(bookDto);
    }


    [HttpPatch("{id}")]
    public IActionResult UpdateBookById(int id, JsonPatchDocument<UpdateBookDto> patch)
    {
        var book = _context.Books.FirstOrDefault(book => book.Id == id);
        if (book == null) return NotFound();

        var bookToUpdate = _mapper.Map<UpdateBookDto>(book);
        patch.ApplyTo(bookToUpdate, ModelState);

        if (!TryValidateModel(bookToUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(bookToUpdate, book);
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
