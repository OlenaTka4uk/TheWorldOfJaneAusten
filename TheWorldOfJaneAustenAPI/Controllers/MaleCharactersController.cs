using Domain.DTO;
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
    }
}
