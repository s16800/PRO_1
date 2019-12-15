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
    public class OrdersController : ControllerBase
    {
        private s16800Context _context;
        public OrdersController(s16800Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_context.Zamówienie.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrder(int id)
        {
            var idzam = _context.Zamówienie.FirstOrDefault(e => e.IdZamówienie == id);
            if (idzam == null)
            {
                return NotFound();
            }

            return Ok(idzam);
        }

        [HttpPost]
        public IActionResult Create(Zamówienie newZamówienie)
        {
            _context.Zamówienie.Add(newZamówienie);
            _context.SaveChanges();

            return StatusCode(201, newZamówienie);
        }

        [HttpPut("{IdZamówienie:int}")]
        public IActionResult Update(Zamówienie updatedZamówienie)
        {

            if (_context.Zamówienie.Count(e => e.IdZamówienie == updatedZamówienie.IdZamówienie) == 0)
            {
                return NotFound();
            }

            _context.Zamówienie.Attach(updatedZamówienie);
            _context.Entry(updatedZamówienie).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedZamówienie);
        }

        [HttpDelete("{IdZamówienie:int}")]
        public IActionResult Delete(int IdZamówienie)
        {
            var IdZam = _context.Zamówienie.FirstOrDefault(e => e.IdZamówienie == IdZamówienie);
            if (IdZam == null)
            {
                return NotFound();
            }

            _context.Zamówienie.Remove(IdZam);
            _context.SaveChanges();


            return Ok(IdZam);
        }

    } 
}