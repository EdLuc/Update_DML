using DemoDapperAPI.Models;
using DemoDapperAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoDapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            var clienteService = new ClientServices();
            {
                var cliente = clienteService.GetClients();
                if (cliente != null)
                {
                    return Ok(cliente);
                }
            }
            return NotFound("Mensaje: There are not clients");
        }

        [HttpGet]
        [Route("ASYNC")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAsync()
        {
            var clienteService = new ClientServices();
            {
                var cliente = await clienteService.GetClientsAsync();
                if (cliente != null)
                {
                    return Ok(cliente);
                }
            }
            return NotFound("Mensaje: There are not clients");
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            var clienteService = new ClientServices();
            {
                var cliente = clienteService.GetClientById(id);
                if (cliente != null)
                {
                    return Ok(cliente);
                }
            }
            return NotFound("Mensaje: There are not client with id: " + id);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            var clienteService = new ClientServices();
            {
                clienteService.AddClient(cliente);
                
            }
            //return NotFound("Mensaje: There are not client with id: " + id);
        }



        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                var clienteService = new ClientServices();
                {
                    cliente.id = id;
                    clienteService.UpdateClient(cliente, true);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPut]
        [Route("Async")]
        public async Task UpdateCientAsync([FromBody] Cliente cliente)
        {
            try
            {
                var clientService = new ClientServices();
                {
                    await clientService.UpdateClientAsync(cliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
