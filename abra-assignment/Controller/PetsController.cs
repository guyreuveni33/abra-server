using Microsoft.AspNetCore.Mvc;
namespace abra_assignment.Controller;

[ApiController]
//this is the url that will be used to access the controller, will be minus the controller name, so in this case it will be /todos
[Route("[controller]")]
public class PetsController:ControllerBase
{
    private readonly MongoDbContext _context;

    public PetsController(MongoDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> AddPet([FromBody] PetItem pet) //values of pets comes from the body of the request
    {
        //Console.WriteLine(pet.Value);
        await _context.Pets.InsertOneAsync(pet);
        return CreatedAtAction(nameof(AddPet), new { id = pet.Id }, pet);
    }
}