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
    public class OrdersController : ControllerBase
    {
        private s17187Context _context;
        public OrdersController(s17187Context context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_context.Zamowienie.ToList());
        }


        [HttpGet("{id:int}")]
        public IActionResult GetOrders(int id)
        {
            var order = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienia == id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("products/{idZamowienia:int}")]
        public IActionResult GetOrderProducts(int idZamowienia)
        {
            var OrdersList = _context.ProduktZamowienie.Where(e => e.IdZamowienia == idZamowienia).ToList();

            if (OrdersList == null)
            {
                return NotFound();
            }

            var idlist = new List<int>();

            foreach (ProduktZamowienie lista in OrdersList)
            {

                idlist.Add(lista.IdProduktu);
                
            }

            var Products = _context.Produkt.Where(e => idlist.Contains(e.IdProduktu)).ToList();

            return Ok(Products);
        }


        //POST
        [HttpPost]
        public IActionResult Create(Zamowienie newOrder)
        {
            _context.Add(newOrder);
            _context.SaveChanges();

            return StatusCode(201, newOrder);
        }


        //PUT
        [HttpPut("{idZamowienia:int}")]
        public IActionResult Update(int idZamowienia, Zamowienie updatedOrder)
        {

            if (_context.Zamowienie.Count(e => e.IdZamowienia == idZamowienia) == 0)
            {
                return NotFound();
            }

            _context.Zamowienie.Attach(updatedOrder);
            _context.Entry(updatedOrder).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedOrder);
        }


        //DELETE
        [HttpDelete("{idZamowienia:int}")]
        public IActionResult Delete(int idZamowienia)
        {
            var order = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienia == idZamowienia);

            if (order == null)
            {
                return NotFound();
            }

            _context.Zamowienie.Remove(order);
            _context.SaveChanges();

            return Ok(order);
        }
    }
}