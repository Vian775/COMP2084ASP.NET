using Microsoft.AspNetCore.Mvc;
using DotNetDrinksWebUI.Data;
using DotNetDrinksWebUI.Models;

namespace DotNetDrinksWebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesApiController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Categories);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cat = _context.Categories.Find(id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }

        [HttpPost]
        public IActionResult Create(Category c)
        {
            _context.Categories.Add(c);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = c.Id }, c);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Category c)
        {
            if (id != c.Id) return BadRequest();
            _context.Categories.Update(c);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var c = _context.Categories.Find(id);
            if (c == null) return NotFound();
            _context.Categories.Remove(c);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
