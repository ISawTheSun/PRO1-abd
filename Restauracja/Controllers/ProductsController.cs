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
    public class ProductsController : ControllerBase
    {
        private readonly s17187Context _context;
        public ProductsController (s17187Context context)
        {
            _context = context;
        }


        //GET
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Produkt.ToList());
        }


        [HttpGet("{idComponent:int}")]
        public IActionResult GetPizzasWithComponent(int idComponent)
        {
            var ComponentsList = _context.ListaSkladnikow.Where(e => e.SkladnikIdSkladnik == idComponent).ToList();

            if (ComponentsList == null)
            {
                return NotFound();
            }

            var PizzaList = new List<Produkt>();

            foreach (ListaSkladnikow lista in ComponentsList)
            {
                var id = lista.IdProduktu;

                PizzaList.Add(_context.Produkt.FirstOrDefault(e => e.IdProduktu == id));
            }


            return Ok(PizzaList);
        }


        //POST
        [HttpPost]
        public IActionResult Create(Produkt newProduct)
        {
            _context.Add(newProduct);
            _context.SaveChanges();

            return StatusCode(201, newProduct);
        }

        //PUT
        [HttpPut("{idProduktu:int}")]
        public IActionResult Update(int idProduktu, Produkt updatedProduct)
        {

            if(_context.Produkt.Count(e => e.IdProduktu == idProduktu) == 0)
            {
                return NotFound();
            }

            _context.Produkt.Attach(updatedProduct);
            _context.Entry(updatedProduct).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedProduct);
        }

        //DELETE
        [HttpDelete("{idProduktu:int}")]
        public IActionResult Delete(int idProduktu)
        {
            var prod = _context.Produkt.FirstOrDefault(e => e.IdProduktu == idProduktu);

            if (prod == null)
            {
                return NotFound();
            }

            _context.Produkt.Remove(prod);
            _context.SaveChanges();

            return Ok(prod);
        }

    }
}