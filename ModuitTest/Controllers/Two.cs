using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ModuitTest.Controllers
{
    [Route("Answer/[controller]")]
    [ApiController]
    public class Two : ControllerBase
    {
        private readonly ILogger<Two> _logger;

        public Two(ILogger<Two> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<ClassModel>> GetAsync()
        {
            List<ClassModel> ListResult = new List<ClassModel>();
            List<ClassModel> ListResult2 = new List<ClassModel>();
            ClassModel ObjModel = new ClassModel();
            int ID;
            List<int> dataID = new List<int> { };
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://screening.moduit.id/backend/question/two"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ListResult = JsonConvert.DeserializeObject<List<ClassModel>>(apiResponse);
                }
                ListResult = ListResult.Where(x => x.description.Contains("Ergonomic") || x.title.Contains("Ergonomic")).ToList();
                foreach (ClassModel item in ListResult)
                {
                    if (item.tags != null)
                    {
                        foreach (string items in item.tags)
                        {
                            if (items.ToString() == "Sports")
                            {
                                ListResult2.Add(item);
                                break;
                            }
                        }
                    }
                }
                ListResult2 = ListResult2.Take(3).ToList().OrderByDescending(x => x.id).ToList();
            }

            return ListResult2;
        }
    }
}
