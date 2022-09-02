using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroClientes.Data;
using CadastroClientes.Models;
using CadastroClientes.Repository;

namespace CadastroClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteRepository _repository;



        public ClientesController(ClienteRepository repository)
        {
            _repository = repository;  
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _repository.GetClientes();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            return await _repository.GetCliente(id);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            //if (id != cliente.Id)
            //    return BadRequest();
            

            return Ok(await _repository.UpdateCliente(cliente));
        }



        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            var novoCliente = await _repository.AddCliente(cliente);

            return CreatedAtAction("GetCliente", new { id = novoCliente.Id }, novoCliente);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _repository.DeleteCliente(id);

            return NoContent();
        }
    }
}