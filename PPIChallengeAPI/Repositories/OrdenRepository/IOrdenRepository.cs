using PPIChallengeAPI.Models;
using PPIChallengeAPI.Models.Entities;
using PPIChallengeAPI.Models.Helpers;

namespace PPIChallengeAPI.Repositories.OrdenRepository
{
    public interface IOrdenRepository
    {
        Task<Orden> GetOrden(int id);
        Task<Orden> CreateOrden(Orden ordenAInsertar);
        Task<Orden> UpdateOrden(OrdenUpdate ordenAModificar);
        Task<int> DeleteOrden(int id);


        Task<Activo> GetActivoByNombre(string activoName);
        Task<Estado> GetEstado(int estadoID);
    }
}
