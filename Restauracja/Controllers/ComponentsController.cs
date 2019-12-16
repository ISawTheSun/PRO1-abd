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
    public class ComponentsController : ControllerBase
    {
        private s17187Context _context;
        public ComponentsController(s17187Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetComponents()
        {
            return Ok(_context.Skladnik.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetComponent(int id)
        {
            var componenet = _context.Skladnik.FirstOrDefault(e => e.IdSkladnik == id);
            if (componenet == null)
            {
                return NotFound();
            }

            return Ok(componenet);
        }



        //POST
        [HttpPost]
        public IActionResult Create(Skladnik newComponent)
        {
            _context.Add(newComponent);
            _context.SaveChanges();

            return StatusCode(201, newComponent);
        }

        //PUT
        [HttpPut("{idSkladnik:int}")]
        public IActionResult Update(int idSkladnik, Skladnik updatedComponent)
        {

            if (_context.Skladnik.Count(e => e.IdSkladnik == idSkladnik) == 0)
            {
                return NotFound();
            }

            _context.Skladnik.Attach(updatedComponent);
            _context.Entry(updatedComponent).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedComponent);
        }

        //DELETE

        [HttpDelete("{idSkladnik:int}")]
        public IActionResult Delete(int idSkladnik)
        {
            var comp = _context.Skladnik.FirstOrDefault(e => e.IdSkladnik == idSkladnik);

            if (comp == null)
            {
                return NotFound();
            }

            _context.Skladnik.Remove(comp);
            _context.SaveChanges();

            return Ok(comp);
        }
    }
}