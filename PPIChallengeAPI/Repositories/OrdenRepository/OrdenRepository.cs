using PPIChallengeAPI.Models;
using PPIChallengeAPI.Models.Entities;
using PPIChallengeAPI.Models.Helpers;

namespace PPIChallengeAPI.Repositories.OrdenRepository
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly DataContext _dataContext;

        public OrdenRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Orden> GetOrden(int id)
        {

            return await _dataContext.Ordenes.FindAsync(id);
        }

        public async Task<Orden> CreateOrden(Orden orden)
        {

            _dataContext.Ordenes.AddAsync(orden);
            _dataContext.SaveChanges();

            return orden;
        }

        public async Task<Orden> UpdateOrden(OrdenUpdate ordenDatos)
        {
            Orden orden = await _dataContext.Ordenes.FindAsync(ordenDatos.ordenID);
            if (orden != null)
            {
                orden.estado = ordenDatos.estadoID;
                _dataContext.SaveChanges();
            }
            

            return orden;
        }

        public async Task<int> DeleteOrden(int ordenID)
        {
            Orden orden = await _dataContext.Ordenes.FindAsync(ordenID);

            _dataContext.Ordenes.Remove(orden);
            int rowsAffected = _dataContext.SaveChanges();

            return rowsAffected;
        }


        public async Task<Activo> GetActivoByNombre(string activoName)
        {
            Activo activo = (
                from a in _dataContext.Activos
                join ta in _dataContext.TiposActivo on a.tipoActivo equals ta.Id
                where (a.nombre == activoName)
                select new Activo
                {
                    id = a.id,
                    ticker = a.ticker,
                    nombre = a.nombre,
                    tipoActivo = a.tipoActivo,
                    activoDescripcion = ta.Descripcion,
                    precioUnitario = a.precioUnitario
                }).FirstOrDefault();


            return activo;
        }

        public async Task<Estado> GetEstado(int estadoID)
        {
            return await _dataContext.Estados.FindAsync(estadoID);
        }
    }
}
