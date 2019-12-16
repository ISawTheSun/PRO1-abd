using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restauracja.Models;

namespace Restauracja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private s17187Context _context;
        public PizzasController(s17187Context context)
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
           var pizza = _context.Pizza.FirstOrDefault(e => e.IdProduktu == id);
           if(pizza == null)
           {
               return NotFound();
           }

          return Ok(pizza);
        }


        //POST
        [HttpPost]
        public IActionResult Create(Pizza newPizza)
        {
            _context.Add(newPizza);
            _context.SaveChanges();

            return StatusCode(201, newPizza);
        }

        //PUT
        [HttpPut("{idProduktu:int}")]
        public IActionResult Update(int idProduktu, Pizza updatedPizza)
        {

            if (_context.Pizza.Count(e => e.IdProduktu == idProduktu) == 0)
            {
                return NotFound();
            }

            _context.Pizza.Attach(updatedPizza);
            _context.Entry(updatedPizza).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizza);
        }

        //DELETE
        [HttpDelete("{idProduktu:int}")]
        public IActionResult Delete(int idProduktu)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdProduktu == idProduktu);

            if (pizza == null)
            {
                return NotFound();
            }

            _context.Pizza.Remove(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }
    }
}