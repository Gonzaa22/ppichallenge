using PPIChallengeAPI.Models;
using PPIChallengeAPI.Models.Entities;
using PPIChallengeAPI.Models.Helpers;

namespace PPIChallengeAPI.Services.OrdenService
{
    public interface IOrdenService
    {
        Task<ApiResponse> GetOrden(int id);
        Task<ApiResponse> PostOrden(OrdenCreate ordenCreate);
        Task<ApiResponse> UpdateOrden(OrdenUpdate ordenUpdate);
        Task<ApiResponse> DeleteOrden(int id);
    }
}
