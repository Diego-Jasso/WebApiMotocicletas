using Microsoft.AspNetCore.Mvc;
using WebApiMotocicletas.Entidades;

namespace WebApiMotocicletas.Controllers
{
    [ApiController]
    [Route("motocicletas")]
    public class motocicletasController : ControllerBase
    {
        [HttpGet]

        public ActionResult<List<motocicletas>> Get() 
        {
            return new List<motocicletas>()
            {
                new motocicletas() { Id = 1, proveedorId = 1, modeloId = 1 , color = "verde", descripcion = ""},
                new motocicletas() { Id = 2, proveedorId = 1, modeloId = 2 , color = "rojo", descripcion = ""}
            };
        }
    }
}
