using ApiSample.Entity;
using ApiSample.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ApiSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PayLoadController : Controller
    {
        private readonly ILogger _logger;
        public PayLoadController(ILogger<PayLoadController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string PayloadApi()
        {
            _logger.LogInformation("Log message in the PayloadApi() method");
            using (StreamReader r = new StreamReader("Data/payload.json"))
            {
                string json = r.ReadToEnd();
                List<PayloadInfo> payload = JsonConvert.DeserializeObject<List<PayloadInfo>>(json);
                string result = SaveData.Save(payload);
                return result;
            }
        }
    }
}
