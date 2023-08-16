using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taco_Bell_Rest_API_Lab.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Taco_Bell_Rest_API_Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private TacoBellDbContext _tacoBellDbContext = new TacoBellDbContext();
        // /api/Drink
        [HttpGet]
        public List<Drink> GetAll()
        {
            return _tacoBellDbContext.Drinks.ToList();
        }

        // /api/Drink/{Id}
        [HttpGet("{Id}")]

        public Drink GetByID(int Id)
        {
            return _tacoBellDbContext.Drinks.FirstOrDefault(d => d.Id == Id);
        }

        [HttpPatch]
        public Drink UpdateName(string oldName, string newName)
        {
            Drink d = Drinks.FirstOrDefault(d => d.Title.ToLower() == oldName.ToLower().Trim());
            d.Name = newName;
            return d;
        }
    }
}
