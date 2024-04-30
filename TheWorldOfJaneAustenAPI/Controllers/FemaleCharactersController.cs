using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistense.Data;

namespace UI.Controllers
{
    [Route("api/femalecharacters")]
    [ApiController]
    public class FemaleCharactersController : ControllerBase
    {
        private readonly ILogger<FemaleCharactersController> _logger;
        private readonly ApplicationDbContext _db;

        public FemaleCharactersController(ILogger<FemaleCharactersController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<FemaleCharactersDTO>> GetAllFemaleCharacters()
        {
            _logger.LogInformation("Get all female characters");
            return Ok(_db.FemaleCharacters);
        }
    }
}
