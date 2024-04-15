using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Animal;

[Route("/api/animal")]
[ApiController]
public class AnimalController : ControllerBase
{
    private IAnimalService _animalService;
    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
    
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAnimals([FromQuery] string orderBy)
    {
        var animals = _animalService.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult CreateAnimal([FromBody] CreateAnimalDTO dto)
    {
        var success = _animalService.CreateAnimal(dto);
        return success ? Created() : Conflict();
    }
}