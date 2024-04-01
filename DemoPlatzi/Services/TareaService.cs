using DemoPlatzi.Models;

namespace DemoPlatzi.Services
{
    public class TareaService : ITareaService
    {
        TareasContext _context;

        public TareaService(TareasContext context)
        {
            _context = context;
        }
        public IEnumerable<Tarea> GetAll()
        {
            return _context.Tareas;
        }

        public async Task Save(Tarea tarea)
        {
            tarea.FechaCreacion = DateTime.Now;
            _context.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Tarea tarea, Guid id)
        {
            var _tarea = _context.Tareas.Find(id);

            if (_tarea != null)
            {
                _tarea.Titulo = tarea.Titulo;
                _tarea.Descripcion = tarea.Descripcion;
                _tarea.PrioridadTarea = tarea.PrioridadTarea;
                _tarea.CategoriaId = tarea.CategoriaId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var _tarea = _context.Tareas.Find(id);

            if (_tarea != null)
            {
                _context.Remove(_tarea);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface ITareaService
    {
        IEnumerable<Tarea> GetAll();
        Task Save(Tarea tarea);
        Task Update(Tarea tarea, Guid id);
        Task Delete(Guid id);
    }
}
