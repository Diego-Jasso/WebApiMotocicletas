using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMotocicletas.Entidades;

namespace WebApiMotocicletas.Controllers
{
    [ApiController]
    [Route("motocicletas")]
    public class motocicletasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public motocicletasController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]

        public ActionResult<List<motocicletas>> Get() 
        {
            return new List<motocicletas>()
            {
                new motocicletas() { Id = 1, modeloId = 1 , color = "verde", descripcion = ""},
                new motocicletas() { Id = 2, modeloId = 2 , color = "rojo", descripcion = ""}
            };
        }

        [HttpPost]
        public async Task<ActionResult> Post(motocicletas motocicletas)
        {
            _context.Add(motocicletas);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("lista")]
        public async Task<ActionResult<List<motocicletas>>> GetAll()
        {
            return await _context.Motocicletas.Include(x => x.proveedores).ToListAsync();
        }

        [HttpPut("{id:int}")]

       public async Task<ActionResult> Put(motocicletas motocicletas, int id)
        {
            if(motocicletas.Id != id)
            {
                return BadRequest("El Id de la motocicleta no coincide con el establecido.");
            }

            _context.Update(motocicletas);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _context.Motocicletas.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("No se encontro la motocicleta en la base de datos");
            }

            _context.Remove(new motocicletas() { Id = id });

            await _context.SaveChangesAsync();
        
            return Ok();
        }

    }
}