using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taco_Bell_Rest_API_Lab.Models;

namespace Taco_Bell_Rest_API_Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacoController : ControllerBase
    {
        private TacoBellDbContext _tacoBellDbContext = new TacoBellDbContext();
        // /api/Taco
        [HttpGet]
        public List<Taco> GetAll() //Name of method doesn't matter
        {
            return _tacoBellDbContext.Tacos.ToList();
        }
        // /api/Taco/{Id}
        [HttpGet("{Id}")]
        public Taco GetByID(int Id)
        {
            return _tacoBellDbContext.Tacos.FirstOrDefault(taco => taco.Id == Id);

        }
        // /api/Taco/soft
        [HttpGet("soft")]
        public List<Taco> GetBeanBurrito(bool SoftShell)
        {
            return _tacoBellDbContext.Tacos.Where(r => r.SoftShell == SoftShell).ToList();
        }


        [HttpPost]
        public Taco AddTaco(string Name, float Cost, bool softShell, bool Dorito)
        {
            Taco newTaco = new Taco();
            newTaco.Name = Name;
            newTaco.Cost = Cost;
            newTaco.SoftShell = softShell;
            newTaco.Dorito = Dorito;

            //entity framework and auto incrementing creates the ID for you
            _tacoBellDbContext.Tacos.Add(newTaco);
            _tacoBellDbContext.SaveChanges();
            return newTaco;
        }
    }
}
