using Microsoft.AspNetCore.Mvc;
using PlatfromService.Data;
using PlatfromService.Dtos;

namespace PlatfromService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;

        public PlatformsController(IPlatformRepo repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<ReadPlatformDto>> GetPlatforms()
        {
            System.Console.WriteLine("Get platforms invoice");
            var listOfItems = _repository.GetAllPlatforms();

            return Ok(listOfItems.AsDtoList());
        }

        [HttpGet("{id}")]
        public ActionResult<ReadPlatformDto> GetPlatfromById(int id)
        {
            var item = _repository.GetPlatformById(id);
            if (item == null)
                return NotFound();
            
            return Ok(item.AsDto());
        }

        [HttpPost]
        public ActionResult<ReadPlatformDto> CreatePlatfrom(CreatePlatformDto platformDto)
        {
            if (platformDto == null)
                return BadRequest();

           var newId = _repository.CreatePlatform(platformDto.DtoAs());
           _repository.SaveChanges();

        var readPlatformDto = new ReadPlatformDto(newId,platformDto.Name,platformDto.Publisher,platformDto.Cost);

            return CreatedAtAction(nameof(CreatePlatfrom),readPlatformDto);
        }   
    }
}