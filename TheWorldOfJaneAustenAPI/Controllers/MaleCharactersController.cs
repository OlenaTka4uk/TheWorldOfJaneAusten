using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistense.Data;

namespace UI.Controllers
{
    [Route("api/malecharacters")]
    [ApiController]
    public class MaleCharactersController : ControllerBase
    {
        private readonly ILogger<MaleCharactersController> _logger;
        private readonly ApplicationDbContext _db;

        public MaleCharactersController(ILogger<MaleCharactersController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<MaleCharactersDTO> GetAllMaleCharacters()
        {
            _logger.LogInformation("Get all male characters");
            return Ok(_db.MaleCharacters);
        }


        [HttpGet("{id:int}", Name = "GetMaleCharById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MaleCharactersDTO> GetMaleCharactersById(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Id can not be zero");
                return BadRequest();
            }

            var maleCharacter = _db.MaleCharacters.FirstOrDefault(x => x.Id == id);

            if (maleCharacter == null)
            {
                _logger.LogError($"{maleCharacter} has not found.");
                return NotFound();
            }

            return Ok(maleCharacter);
        }


        [HttpGet("name:string", Name = "GetMaleCharByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MaleCharactersDTO> GetMaleCharacterByName(string name)
        {
            if (name == "")
            {
                _logger.LogError("The name can not be empty");
                return BadRequest();
            }

            var maleCharacter = _db.MaleCharacters.FirstOrDefault(x => x.Name == name);

            if (maleCharacter == null)
            {
                _logger.LogError($"{maleCharacter} isn't exist");
                return NotFound();
            }

            return Ok(maleCharacter);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MaleCharacter> CreateMaleCharacter([FromBody] MaleCharactersDTO maleCharactersDTO)
        {
            if (_db.MaleCharacters.FirstOrDefault(x => x.Name.ToLower() == maleCharactersDTO.Name.ToLower()) != null)
            {
                _logger.LogError($"{maleCharactersDTO} is exist");
                return BadRequest();
            }

            if (maleCharactersDTO == null)
            {
                _logger.LogError($"{maleCharactersDTO} is not exist");
                return NotFound();
            }

            if (maleCharactersDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            MaleCharacter model = new ()
            { 
                Id = maleCharactersDTO.Id,
                Name = maleCharactersDTO.Name,
                BookId = maleCharactersDTO.BookId,
                Characteristic = maleCharactersDTO.Characteristic
            };

            _db.MaleCharacters.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetMaleCharById", new { id = maleCharactersDTO.Id }, maleCharactersDTO);

        }
    }
}
