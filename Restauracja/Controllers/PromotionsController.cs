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
    public class PromotionsController : ControllerBase
    {
        private s17187Context _context;
        public PromotionsController(s17187Context context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetPromotions()
        {
            return Ok(_context.Promocja.ToList());
        }


        [HttpGet("{id:int}")]
        public IActionResult GetPromotion(int id)
        {
            var promocja = _context.Promocja.FirstOrDefault(e => e.IdPromocji == id);
            if (promocja == null)
            {
                return NotFound();
            }

            return Ok(promocja);
        }


        //POST
        [HttpPost]
        public IActionResult Create(Promocja newPromotion)
        {
            _context.Add(newPromotion);
            _context.SaveChanges();

            return StatusCode(201, newPromotion);
        }

        //PUT
        [HttpPut("{idPromocji:int}")]
        public IActionResult Update(int idPromocji, Promocja updatedPromotion)
        {

            if (_context.Promocja.Count(e => e.IdPromocji == idPromocji) == 0)
            {
                return NotFound();
            }

            _context.Promocja.Attach(updatedPromotion);
            _context.Entry(updatedPromotion).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPromotion);
        }

        //DELETE
        [HttpDelete("{idPromocji:int}")]
        public IActionResult Delete(int idPromocji)
        {
            var prom = _context.Promocja.FirstOrDefault(e => e.IdPromocji == idPromocji);

            if (prom == null)
            {
                return NotFound();
            }

            _context.Promocja.Remove(prom);
            _context.SaveChanges();

            return Ok(prom);
        }
    }
}