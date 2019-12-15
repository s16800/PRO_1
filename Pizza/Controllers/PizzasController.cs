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
    public class PizzasController : ControllerBase
    {

        private s16800Context _context;
        public PizzasController(s16800Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.PizzaBaza.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            var idpizza = _context.PizzaBaza.FirstOrDefault(e => e.IdPizza == id);
            if (idpizza == null)
            {
                return NotFound();
            }

            return Ok(idpizza);

        }

        [HttpPost]
        public IActionResult Create(PizzaBaza newPizzaBaza)
        {
            _context.PizzaBaza.Add(newPizzaBaza);
            _context.SaveChanges();

            return StatusCode(201, newPizzaBaza);
        }

        [HttpPut("{IdPizza:int}")]
        public IActionResult Update(PizzaBaza updatedPizzaBaza)
        {

            if(_context.PizzaBaza.Count(e => e.IdPizza == updatedPizzaBaza.IdPizza) == 0)
            {
                return NotFound();
            }

            _context.PizzaBaza.Attach(updatedPizzaBaza);
            _context.Entry(updatedPizzaBaza).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizzaBaza);
        }

        [HttpDelete("{IdPizza:int}")]
        public IActionResult Delete(int IdPizza)
        {
            var IdPiz = _context.PizzaBaza.FirstOrDefault(e => e.IdPizza == IdPizza);
            if(IdPiz == null)
            {
                return NotFound();
            }

            _context.PizzaBaza.Remove(IdPiz);
            _context.SaveChanges();


            return Ok(IdPiz);
        }
    }

}
