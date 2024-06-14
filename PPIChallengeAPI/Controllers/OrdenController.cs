using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PPIChallengeAPI.Models;
using PPIChallengeAPI.Models.Entities;
using PPIChallengeAPI.Models.Helpers;
using PPIChallengeAPI.Services.OrdenService;

namespace PPIChallengeAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
       
        private readonly IOrdenService _ordenService;

        public OrdenController(IOrdenService ordenService)
        {
            _ordenService = ordenService;
        }

        [Route("api/[controller]/GetOrden/{id}")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetOrden(int id)
        {
            var result = await _ordenService.GetOrden(id);

            if (result.statusCode != 200)
                return NotFound();

            return Ok(JsonConvert.SerializeObject(result, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [Route("api/[controller]/PostOrden")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> PostOrden(OrdenCreate ordenCreate)
        {
            var result = await _ordenService.PostOrden(ordenCreate);

            if(result.statusCode != 200)
                return BadRequest(result);

            return Ok(JsonConvert.SerializeObject(result, new JsonSerializerSettings { Formatting = Formatting.Indented}));
        }

        [Route("api/[controller]/UpdateOrden")]
        [HttpPut]
        public async Task<ActionResult<ApiResponse>> UpdateOrden(OrdenUpdate ordenUpdate)
        {
            var result = await _ordenService.UpdateOrden(ordenUpdate);

            if (result.statusCode != 200)
                return BadRequest(result);

            return Ok(JsonConvert.SerializeObject(result, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [Route("api/[controller]/DeleteOrden/{id}")]
        [HttpDelete]
        public async Task<ActionResult<ApiResponse>> DeleteOrden(int id)
        {
            var result = await _ordenService.DeleteOrden(id);

            if(result.statusCode != 200)
                return BadRequest(result);

            return Ok(JsonConvert.SerializeObject(result, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
    }
}
