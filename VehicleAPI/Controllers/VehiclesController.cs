using Microsoft.AspNetCore.Mvc;
using VehicleAPI.Models;

namespace VehicleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private static readonly List<Vehicle> Data = [];

        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> Get(string? make, int? year)
        {
            var result = Data.AsEnumerable();

            if (!string.IsNullOrEmpty(make))
            {
                result = result.Where(v => v.Make.Contains(make, StringComparison.OrdinalIgnoreCase));
            }

            if (year > 0)
            {
                result = result.Where(v => v.Year == year);
            }    
            return Ok(result.ToList());
        }
    }
}
