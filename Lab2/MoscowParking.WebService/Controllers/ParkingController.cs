using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoscowParking.DomainObjects;

namespace MoscowParking.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly ILogger<ParkingController> _logger;

        public ParkingController(ILogger<ParkingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Parking> GetParking()
        {
            return new List<Parking>() 
            { 
                new Parking() 
                {
                    Name = "ТПУ Кожуховская",
                    PlaceNumber = "9909",
                    AdmArea = "Юго-Восточный административный округ",
                    District = "район Печатники",
                    Address = "улица Южнопортовая, владение 3",
                    Hours = "круглосуточно",
                    CountSpaces = 62,
                } 
            };
        }
    }
}
