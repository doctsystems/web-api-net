using DemoPlatzi.Models;

namespace DemoPlatzi.Services
{
    public class CategoriaService : ICategoriaService
    {
        TareasContext _context;

        public CategoriaService(TareasContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _context.Categorias.ToList();
        }

        public async Task Save(Categoria categoria)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Categoria categoria, Guid id)
        {
            var _categoria  = _context.Categorias.Find(id);

            if (_categoria != null)
            {
                _categoria.Nombre = categoria.Nombre;
                _categoria.Descripcion = categoria.Descripcion;
                _categoria.Peso = categoria.Peso;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var _categoria = _context.Categorias.Find(id);

            if (_categoria != null)
            {
                _context.Remove(_categoria);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetAll();
        Task Save(Categoria categoria);
        Task Update(Categoria categoria, Guid id);
        Task Delete(Guid id);
    }
}
