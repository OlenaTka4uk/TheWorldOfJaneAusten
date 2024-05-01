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

        [HttpGet("{id:int}", Name = "GetOneCharById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FemaleCharactersDTO> GetFemaleCharactersById(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Id can not be zero");
                return BadRequest();
            }

            var femaleCharacter = _db.FemaleCharacters.FirstOrDefault(x => x.Id == id);

            if (femaleCharacter == null)
            {
                _logger.LogError($"{femaleCharacter} has not found.");
                return NotFound();
            }

            return Ok(femaleCharacter);
        }


        [HttpGet("name:string", Name = "GetOneCharByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FemaleCharactersDTO> GetFemaleCharacterByName(string name)
        {
            if (name == "")
            {
                _logger.LogError("The name can not be empty");
                return BadRequest();
            }

            var femaleCharacter = _db.FemaleCharacters.FirstOrDefault(x => x.Name == name);

            if (femaleCharacter == null)
            {
                _logger.LogError($"{femaleCharacter} isn't exist");
                return NotFound();
            }

            return Ok(femaleCharacter);
        }
    }
}
