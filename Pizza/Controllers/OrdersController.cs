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
    }
}