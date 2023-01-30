using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController: ControllerBase
	{

		private static List<SuperHero> heroes = new List<SuperHero>
		{
            new SuperHero{
                Id= 1,
                Name="Spider Man",
                FirstName="Peter",
                LastName="Parker",
                Place="New York City"
            },
            new SuperHero{
                Id= 2,
                Name="Iron Man",
                FirstName="Tony",
                LastName="Stark",
                Place="Long Island"
            }
        };
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(this._context.SuperHeroes.ToList());
            //return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not found!");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            //heroes.Add(hero);
            this._context.SuperHeroes.Add(hero);
            this._context.SaveChanges();

            return Ok(this._context.SuperHeroes.ToList());
            //return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
                return BadRequest("Hero not found!");
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(hero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not found!");
            heroes.Remove(hero);

            return Ok(heroes);
        }
    }
}

