using APIPostgreSQL.Entidades;
using APIPostgreSQL.Service;
using Microsoft.AspNetCore.Mvc;

namespace APIPostgreSQL.Controller
{
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosService pedidosService;
        public PedidosController(PedidosService pedidosService)
        {
            this.pedidosService = pedidosService;
        }
        [HttpGet]
        public IActionResult Listar(int? id)
        {
            var clientes = id.HasValue ? pedidosService.Listar(id.Value) : pedidosService.Listar();
            return Ok(clientes);
        }
        [HttpPost]
        public IActionResult Criar(Pedidos pedido)
        {
            if (pedido == null)
            {
                return BadRequest(ModelState);
            }
            var sucesso = pedidosService.Criar(pedido);
            if (sucesso)
            {
                return Ok(pedido);
            }
            else
            {
                return UnprocessableEntity();
            }
        }

        [HttpPut]
        public IActionResult Editar(Pedidos pedido)
        {
            if (pedido == null)
            {
                return BadRequest(ModelState);
            }
            var sucesso = pedidosService.Editar(pedido);
            if (sucesso)
            {
                return Ok(pedido);
            }
            else
            {
                return UnprocessableEntity(pedido);
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult Excluir(int Id)
        {
            var pedido = pedidosService.Excluir(Id);
            if (pedido == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(pedido);
            }
        }

    }
}
