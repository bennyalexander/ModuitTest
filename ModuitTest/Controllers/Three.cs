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
    [Route("Answer/[controller]")]
    [ApiController]
    public class Three : ControllerBase
    {
        private readonly ILogger<Three> _logger;

        public Three(ILogger<Three> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Model3>> GetAsync()
        {
            List<model3Temp> ListResult = new List<model3Temp>();
            List<Model3> ListResult2 = new List<Model3>();
            Model3 members = new Model3();
           
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://screening.moduit.id/backend/question/three"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ListResult = JsonConvert.DeserializeObject<List<model3Temp>>(apiResponse);
                }
                foreach (model3Temp item in ListResult)
                {
                    if(item.items != null)
                    {
                        foreach (items items in item.items)
                        {
                            members = new Model3()
                            {
                                category=item.category,
                                createdAt=item.createdAt,
                                description=items.description,
                                footer=items.footer,
                                id=item.id,
                                title=items.title
                            };
                            ListResult2.Add(members);
                        }
                    }
                }
            }

            return ListResult2;
        }
    }
}
