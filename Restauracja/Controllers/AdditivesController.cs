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
    public class AdditivesController : ControllerBase
    {
        private s17187Context _context;
        public AdditivesController(s17187Context context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAdditives()
        {
            return Ok(_context.Dodatek.ToList());
        }


        [HttpGet("{id:int}")]
        public IActionResult GetAdditive(int id)
        {
            var additive = _context.Dodatek.FirstOrDefault(e => e.IdProduktu == id);
            if (additive == null)
            {
                return NotFound();
            }

            return Ok(additive);
        }


        //POST
        [HttpPost]
        public IActionResult Create(Dodatek newAdditive)
        {
            _context.Add(newAdditive);
            _context.SaveChanges();

            return StatusCode(201, newAdditive);
        }

        //PUT
        [HttpPut("{idProduktu:int}")]
        public IActionResult Update(int idProduktu, Dodatek updatedAdditive)
        {

            if (_context.Dodatek.Count(e => e.IdProduktu == idProduktu) == 0)
            {
                return NotFound();
            }

            _context.Dodatek.Attach(updatedAdditive);
            _context.Entry(updatedAdditive).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedAdditive);
        }

        //DELETE

        [HttpDelete("{idProduktu:int}")]
        public IActionResult Delete(int idProduktu)
        {
            var additive = _context.Dodatek.FirstOrDefault(e => e.IdProduktu == idProduktu);

            if (additive == null)
            {
                return NotFound();
            }

            _context.Dodatek.Remove(additive);
            _context.SaveChanges();

            return Ok(additive);
        }
    }
}