using Domain.DTO;
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
    }
}
