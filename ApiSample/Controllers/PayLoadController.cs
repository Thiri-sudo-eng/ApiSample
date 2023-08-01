using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using Newtonsoft.Json;
using ApiSample.Model;
using ApiSample.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

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
                return json;
            }
        }
    }
}
