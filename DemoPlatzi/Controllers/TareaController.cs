using DemoPlatzi.Models;
using DemoPlatzi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoPlatzi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        ITareaService tareaService;

        public TareaController(ITareaService tareaService)
        {
            this.tareaService = tareaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tareaService.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            tareaService.Save(tarea);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Tarea tarea, Guid id)
        {
            tareaService.Update(tarea, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            tareaService.Delete(id);
            return Ok();
        }
    }
}
