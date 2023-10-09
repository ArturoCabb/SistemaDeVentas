using Microsoft.AspNetCore.Mvc;
using NegocioLimpieza.Data.Repositories;
using NegocioLimpieza.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaNegocioLimpieza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoLimpiezaController : ControllerBase
    {
        private readonly IProductoLimpiezaRepository _productoLimpiezaRepository;

        public ProductoLimpiezaController(IProductoLimpiezaRepository productoLimpiezaRepository)
        {
            _productoLimpiezaRepository = productoLimpiezaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productoLimpiezaRepository.GetAllProductos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productoLimpiezaRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductoLimpieza producto)
        {
            if (producto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creaed = await _productoLimpiezaRepository.InsertarProducto(producto);

            return Created("created", creaed);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] ProductoLimpieza producto)
        {
            if (producto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productoLimpiezaRepository.UpdateProducto(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productoLimpiezaRepository.DeleteProducto(id);
            return NoContent();
        }
    }
}
