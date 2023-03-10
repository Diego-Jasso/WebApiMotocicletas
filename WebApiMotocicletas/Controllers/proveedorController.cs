using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMotocicletas.Entidades;


namespace WebApiMotocicletas.Controllers
{
    [ApiController]
    [Route("proveedor")]
    public class proveedorController:ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public proveedorController(ApplicationDbContext context)
        {
            _context = context; 
        }

        [HttpGet]

        public async Task<ActionResult<List<proveedor>>> GetAll()
        {
            return await _context.Proveedor.ToListAsync();
        }

        [HttpGet("lista")]

        public async Task<ActionResult<proveedor>> GetById(int id)
        {
            return await _context.Proveedor.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(proveedor proveedor)
        {
            var existemoto = await _context.Motocicletas.AnyAsync(x => x.Id == proveedor.MotocicletasId);

            if (!existemoto)
            {
                return BadRequest("No existe la motocicleta");

            }
            _context.Add(proveedor);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(proveedor proveedor, int id)
        {
            var existeproveedor = await _context.Proveedor.AnyAsync(x => x.Id == proveedor.Id);

            if (!existeproveedor)
            {
                return BadRequest("No existe el proveedor");
            }

            if (proveedor.Id != id)
            {
                return BadRequest("El id del proveedor no coincide con el establecido.");
            }

            _context.Update(proveedor);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _context.Proveedor.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("No se encontro el proveedor en la base de datos.");
            }

            _context.Remove(new proveedor()
            {
                Id = id
            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
