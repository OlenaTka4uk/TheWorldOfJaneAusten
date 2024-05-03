using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistense.Data;

namespace UI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<BooksController> _logger;

        public BooksController(ApplicationDbContext db, ILogger<BooksController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<BookDTO>> GetAllBooks()
        {
            _logger.LogInformation("Get all books");

            return Ok(_db.Books);
        }

        [HttpGet("{id:int}", Name = "GetOneBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookDTO> GetBookById(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Id can not to be zero");
                return BadRequest();
            }

            var book = _db.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                _logger.LogError($"Book {book} is not found");
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("name:string", Name = "GetBookByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookDTO> GetBookByName(string name)
        {
            if (name == "")
            {
                _logger.LogError("The name can not be empty");
                return BadRequest();
            }

            var book = _db.Books.FirstOrDefault(x => x.Title == name);
            if (book == null)
            {
                _logger.LogError($"Book {book} is not found");
                return NotFound();
            }

            return Ok(book);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookDTO> CreateBook([FromBody] BookDTO bookDTO)
        {
            if (_db.Books.FirstOrDefault(x => x.Title.ToLower() == bookDTO.Title.ToLower()) != null)
            {
                _logger.LogError("This book is already exist!");
                return BadRequest();
            }

            if (bookDTO == null)
            {
                _logger.LogError($"{bookDTO} is not found");
                return NotFound(bookDTO);
            }

            if (bookDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Book model = new()
            { 
                
                Id = bookDTO.Id,      
                Title = bookDTO.Title,
                Year = bookDTO.Year,
                Description = bookDTO.Description            
            };

            _db.Books.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetOneBook", new { id = bookDTO.Id }, bookDTO);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBook(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var book = _db.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return BadRequest();
            }

            _db.Books.Remove(book);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateBook(int id, [FromBody] BookDTO bookDTO)
        {
            if (id == 0 || bookDTO == null)
            {
                _logger.LogError("Wrong data");
                return BadRequest();
            }

            var book = _db.Books.FirstOrDefault(x => x.Id == id);
            book.Id = bookDTO.Id;
            book.Title = bookDTO.Title;
            book.Year = bookDTO.Year;
            book.Description = bookDTO.Description;

            _db.Books.Update(book);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
