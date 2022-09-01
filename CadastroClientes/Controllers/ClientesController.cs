using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroClientes.Data;
using CadastroClientes.Models;



namespace CadastroClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;



        public ClientesController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            return  _context.Clientes.ToList();
        }



        
        [HttpGet("{id}")]
        public ActionResult<Cliente> GetCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);



            if (cliente == null)
            {
                return NotFound();
            }



            return cliente;
        }



        
        [HttpPut("{id}")]
        public  IActionResult PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }



            _context.Entry(cliente).State = EntityState.Modified;



            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }



            return NoContent();
        }



       
        [HttpPost]
        public ActionResult<Cliente> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
             _context.SaveChanges();



            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }



        [HttpDelete("{id}")]
        public  IActionResult DeleteCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }



            _context.Clientes.Remove(cliente);
            _context.SaveChanges();



            return NoContent();
        }



        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}