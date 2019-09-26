using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities;
using Resources;
namespace AppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        // GET: api/Utility
        [HttpGet]
        public string Get()
        {
            var temperature = Utilities.Utilities
                .RandomDecimalValueInRange(Constants.TemperatureMin, Constants.TemperatureMax,Constants.RoundUp).ToString(CultureInfo.InvariantCulture);
            var spo2 = Utilities.Utilities.RandomNumberInRange(Constants.Spo2Min, Constants.Spo2Max).ToString();
            var pulseRate = Utilities.Utilities.RandomNumberInRange(Constants.PulseRateMin, Constants.PulseRateMax)
                .ToString();
            return temperature + "," + spo2 + "," + pulseRate;
        }

        // GET: api/Utility/B
        [HttpGet("{idType}", Name = "Get")]
        public string Get(string idType)
        {
            return Utilities.Utilities.IdGenerator(idType);
        }

     
    }
}
