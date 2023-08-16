using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;
using Taco_Bell_Rest_API_Lab.Models;

namespace Taco_Bell_Rest_API_Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurritoController : ControllerBase
    {
        private TacoBellDbContext _tacoBellDbContext = new TacoBellDbContext();

        // /api/Burrito
        [HttpGet]
        public List<Burrito> GetAll() //Name of method doesn't matter
        {
            return _tacoBellDbContext.Burritos.ToList();
        }
        // /api/Burrito/{Id}
        [HttpGet("{Id}")]
        public Burrito GetByID(int Id)
        {
            return _tacoBellDbContext.Burritos.FirstOrDefault(b => b.Id == Id);

        }
        // /api/Burrito/bean
        [HttpGet("bean")]
        public List<Burrito> GetBeanBurrito(bool b)
        {
            return _tacoBellDbContext.Burritos.Where(r => r.Bean == b).ToList();
        }
        // /api/Burrito
        [HttpPost]
        public Burrito AddBurrito(string Name, float Cost, bool Bean)
        {
            Burrito newBurrito = new Burrito();
            newBurrito.Name = Name;
            newBurrito.Cost = Cost;
            newBurrito.Bean = Bean;
            //entity framework and auto incrementing creates the ID for you
            _tacoBellDbContext.Burritos.Add(newBurrito);
            _tacoBellDbContext.SaveChanges();
            return newBurrito;
        }

        // /api/Burrito/Delete/{Id}
        [HttpDelete("Delete/{Id}")]
        public Burrito DeleteBurrito(int Id)
        {
            Burrito c = _tacoBellDbContext.Burritos.FirstOrDefault(c => c.Id == Id);
            _tacoBellDbContext.Burritos.Remove(c);
            _tacoBellDbContext.SaveChanges();
            return c;
        }

    }
}
