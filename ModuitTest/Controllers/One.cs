using Aspose.Words.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ModuitTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class One : ControllerBase
    {
        private readonly ILogger<One> _logger;

        public One(ILogger<One> logger)
        {
            _logger = logger;
        }



        [HttpGet]
        public async Task<ClassModel> GetAsync()
        {
            List<ClassModel> ListResult = new List<ClassModel>();
            ClassModel member = new ClassModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://screening.moduit.id/backend/question/one"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(apiResponse);
                    member = JsonConvert.DeserializeObject<ClassModel>(json.ToString());
                }
            }

            return member;
        }
    }
}
