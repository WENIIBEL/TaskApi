using TaskApi.Models;
using TaskApi.Repositories;
namespace TaskApi.Services
{
    public class TareaService
    {
        private readonly TareaRepository _repository;
        public TareaService(TareaRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<TareaModel>> ObtenerTodas()
        {
            return await _repository.ObtenerTodas();
        }
        public async Task<TareaModel?> ObtenerPorId(int id)
        {

            return await _repository.ObtenerPorId(id);
        }
        public async Task<int> Crear(TareaModel tarea)
        {
            tarea.FechaCreacion = DateTime.Now;
            return await _repository.Crear(tarea);
        }
        public async Task<bool> Actualizar(TareaModel tarea)
        {
            return await _repository.Actualizar(tarea);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repository.Eliminar(id);
        }
    }

}
