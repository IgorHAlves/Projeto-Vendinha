using APIPostgreSQL.Entidades;
using APIPostgreSQL.Service;
using Microsoft.AspNetCore.Mvc;

namespace APIPostgreSQL.Controller
{
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService clienteService;
        public ClienteController(ClienteService clienteService)
        {
            this.clienteService = clienteService;
        }
        [HttpGet]
        public IActionResult Listar(string nome)
        {
            var clientes = string.IsNullOrEmpty(nome) ? clienteService.Listar() : clienteService.Listar(nome);
            return Ok(clientes);
        }
        [HttpPost]
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

        [HttpPut]
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
        [HttpDelete("{Id}")]
        public IActionResult Excluir(int Id)
        {
            var cliente = clienteService.Excluir(Id);
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
