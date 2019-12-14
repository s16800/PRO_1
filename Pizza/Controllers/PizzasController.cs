using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            var idpizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == id);
            if (idpizza == null)
            {
                return NotFound();
            }

            return Ok(idpizza);

        }

    }
}