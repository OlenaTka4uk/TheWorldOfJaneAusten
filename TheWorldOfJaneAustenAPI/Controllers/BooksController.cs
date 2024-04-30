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
    }
}
