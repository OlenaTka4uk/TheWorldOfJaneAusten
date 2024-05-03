using Domain.DTO;
using Domain.Entities;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FemaleCharactersDTO> CreateFemaleCharacter([FromBody] FemaleCharactersDTO femaleCharactersDTO) 
        { 
            if (_db.FemaleCharacters.FirstOrDefault(x => x.Name.ToLower() == femaleCharactersDTO.Name.ToLower()) != null)
            {
                _logger.LogError($"{femaleCharactersDTO.Name} is exist");
                return BadRequest();
            }        

            if (femaleCharactersDTO == null)
            {
                _logger.LogError("This character is nor exist");
                return NotFound(femaleCharactersDTO);
            }
            if (femaleCharactersDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            FemaleCharacter model = new ()
            {
                Id = femaleCharactersDTO.Id,
                Name = femaleCharactersDTO.Name,
                BookId = femaleCharactersDTO.BookId,
                Characteristic = femaleCharactersDTO.Characteristic
            };

            _db.FemaleCharacters.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetOneCharById", new { id = femaleCharactersDTO.Id }, femaleCharactersDTO);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteFemaleCharacter(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var femaleCharacter = _db.FemaleCharacters.FirstOrDefault(x => x.Id == id);

            if (femaleCharacter == null)
            {
                return BadRequest(femaleCharacter);
            }

            _db.FemaleCharacters.Remove(femaleCharacter);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateFemaleCharacter")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateFemaleCharacter(int id, [FromBody] FemaleCharactersDTO femaleCharactersDTO)
        {
            if (id == 0 || femaleCharactersDTO == null)
            {
                _logger.LogError("Wrong data");
                return BadRequest();
            }

            var femaleCharacter = _db.FemaleCharacters.FirstOrDefault(x => x.Id == id);
            femaleCharacter.Id = femaleCharactersDTO.Id;
            femaleCharacter.Name = femaleCharactersDTO.Name;
            femaleCharacter.Characteristic = femaleCharactersDTO.Characteristic;
            femaleCharacter.BookId = femaleCharactersDTO.BookId;

            _db.FemaleCharacters.Update(femaleCharacter);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
