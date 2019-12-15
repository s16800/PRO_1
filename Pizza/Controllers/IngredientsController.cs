using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.Models;

namespace Pizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {

        private s16800Context _context;
        public IngredientsController(s16800Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetIngredient()
        {
            return Ok(_context.Składnik.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetIngredients(int id)
        {
            var idsklad = _context.Składnik.FirstOrDefault(e => e.IdSkładnik == id);
            if (idsklad == null)
            {
                return NotFound();
            }

            return Ok(idsklad);
        }

        [HttpPost]
        public IActionResult Create(Składnik newSkładnik)
        {
            _context.Składnik.Add(newSkładnik);
            _context.SaveChanges();

            return StatusCode(201, newSkładnik);
        }

        [HttpPut("{IdSkładnik:int}")]
        public IActionResult Update(Składnik updatedSkładnik)
        {

            if (_context.Składnik.Count(e => e.IdSkładnik == updatedSkładnik.IdSkładnik) == 0)
            {
                return NotFound();
            }

            _context.Składnik.Attach(updatedSkładnik);
            _context.Entry(updatedSkładnik).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedSkładnik);
        }

        [HttpDelete("{IdSkładnik:int}")]
        public IActionResult Delete(int IdSkładnik)
        {
            var idsklad = _context.Składnik.FirstOrDefault(e => e.IdSkładnik == IdSkładnik);
            if (idsklad == null)
            {
                return NotFound();
            }

            _context.Składnik.Remove(idsklad);
            _context.SaveChanges();


            return Ok(idsklad);
        }

    }
}