using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PPIChallengeAPI.Models;
using PPIChallengeAPI.Models.Entities;
using PPIChallengeAPI.Models.Helpers;
using PPIChallengeAPI.Repositories.OrdenRepository;

namespace PPIChallengeAPI.Services.OrdenService
{
    public class OrdenService : IOrdenService
    {
        private readonly IOrdenRepository _ordenRepository;

        public OrdenService(IOrdenRepository ordenRepository)
        {
            _ordenRepository = ordenRepository;
        }

        public async Task<ApiResponse> GetOrden(int id)
        {
            var orden = await _ordenRepository.GetOrden(id);

            if(orden == null)
                return new ApiResponse(400, "No se encontró ninguna orden con ese id", null);

            return new ApiResponse(200, "", JObject.FromObject(orden));

        }

        public async Task<ApiResponse> PostOrden(OrdenCreate ordenCreate)
        {

            Activo activo = await _ordenRepository.GetActivoByNombre(ordenCreate.activoNombre);

            if (activo == null)
                return new ApiResponse(400, "El activo no existe", null);

            if (ordenCreate.cantidad <= 0)
                return new ApiResponse(400, "La cantidad debe ser mayor a 0", null);

            if (ordenCreate.precio <= 0 && activo.activoDescripcion != "Acción")
                return new ApiResponse(400, "El precio debe ser mayor a 0", null);

            if (ordenCreate.operacion.CompareTo('C') != 0 && ordenCreate.operacion.CompareTo('V') != 0)
                return new ApiResponse(400, "La operación no es valida (Debe ser Venta(V) o Compra(C)", null);


            decimal montoParcial, montoTotal = 0m;
            switch (activo.activoDescripcion)
            {
                case "Acción":
                    ordenCreate.precio = activo.precioUnitario;
                    montoParcial = ordenCreate.cantidad * activo.precioUnitario;
                    montoTotal = (montoParcial) + montoParcial * 0.06m + montoParcial * 0.06m * 0.21m;

                    break;
                case "FCI":
                    montoTotal = ordenCreate.cantidad * ordenCreate.precio;

                    break;
                case "Bono":
                    montoParcial = ordenCreate.cantidad * ordenCreate.precio;
                    montoTotal = (montoParcial) + montoParcial * 0.02m + montoParcial * 0.02m * 0.21m;

                    break;
            }

            Orden ordenAInsertar = new Orden()
            {
                cuentaID = ordenCreate.cuentaId,
                activoNombre = ordenCreate.activoNombre,
                cantidad = ordenCreate.cantidad,
                precio = ordenCreate.precio,
                operacion = ordenCreate.operacion,
                estado = 0,
                montoTotal = montoTotal
            };

            var orden = await _ordenRepository.CreateOrden(ordenAInsertar);

            if (orden == null)
                return new ApiResponse(500, "Hubo un error al insertar", null);

            return new ApiResponse(200, "", JObject.FromObject(orden));

        }

        public async Task<ApiResponse> UpdateOrden(OrdenUpdate ordenUpdate)
        {
            ApiResponse result;
            //Chequear que el estado sea valido

            Estado estado = await _ordenRepository.GetEstado(ordenUpdate.estadoID);
            if (estado == null)
                return new ApiResponse(401, "El estado al que se quiere modificar no existe", null);

            //Chequear que la orden exista y se pueda modificar

            Orden orden = await _ordenRepository.GetOrden(ordenUpdate.ordenID);
            if (orden == null)
                return new ApiResponse(401, "No existe la orden que se quiere modificar", null);

            if (estado.id <= orden.estado)
                return new ApiResponse(401, "No se puede modificar al estado que se desea. Estado actual: " + orden.estadoDescripcion, new JObject());


            var ordenModificada = await _ordenRepository.UpdateOrden(ordenUpdate);

            return new ApiResponse(200, "", JObject.FromObject(ordenModificada));
        }

        public async Task<ApiResponse> DeleteOrden(int id)
        {
            Orden orden = await _ordenRepository.GetOrden(id);

            if (orden == null)
                return new ApiResponse(400, "No existe la orden que se desea eliminar", null);

            int rowsAffected = await _ordenRepository.DeleteOrden(id);

            if (rowsAffected == 0)
                return new ApiResponse(401, "", null);

            return new ApiResponse(200, "", JObject.FromObject(new { registrosAfectados = rowsAffected }));
        }
    }
}
