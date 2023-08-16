using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taco_Bell_Rest_API_Lab.Models;

namespace Taco_Bell_Rest_API_Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private TacoBellDbContext _tacoBellDbContext = new TacoBellDbContext();

        [HttpGet]
        public List<Drink> GetAll()
        {
            return _tacoBellDbContext.Drinks.ToList();
        }

        [HttpGet("{Id}")]

        public Drink GetByID(int id)
        {
            return _tacoBellDbContext.Drinks.FirstOrDefault(d => d.Id == id);
        }
    }
}
