using APIPostgreSQL.Entidades;
using APIPostgreSQL.Service;
using Microsoft.AspNetCore.Mvc;

namespace APIPostgreSQL.Controller
{
    [Route("api/")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService clienteService;
        public ClienteController(ClienteService clienteService)
        {
            this.clienteService = clienteService;
        }
        [HttpGet("cliente")]
        public IActionResult Listar(string nome)
        {
            var clientes = string.IsNullOrEmpty(nome) ? clienteService.Listar() : clienteService.Listar(nome);
            return Ok(clientes);
        }
        [HttpPost("cliente")]
        public IActionResult Criar(Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest(ModelState);
            }
            var sucesso = clienteService.Criar(cliente);
            if (sucesso)
            {
                return Ok(cliente);
            }
            else
            {
                return UnprocessableEntity();
            }
        }

        [HttpPut("cliente")]
        public IActionResult Editar(Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest(ModelState);
            }
            var sucesso = clienteService.Editar(cliente);
            if (sucesso)
            {
                return Ok(cliente);
            }
            else
            {
                return UnprocessableEntity(cliente);
            }
        }
        [HttpDelete("cliente/{id}")]
        public IActionResult Excluir(int id)
        {
            var cliente = clienteService.Excluir(id);
            if (cliente == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cliente);
            }
        }

    }
}
