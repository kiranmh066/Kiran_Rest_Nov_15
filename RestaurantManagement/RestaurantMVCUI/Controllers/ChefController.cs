using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestaurantEntity;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestaurantMVCUI.Controllers
{
    public class ChefController : Controller
    {
        private IConfiguration _configuration;

        public ChefController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(Cook cook)
        {
            IEnumerable<Cook> cookresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Cook/GetCooks";

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        cookresult = JsonConvert.DeserializeObject<IEnumerable<Cook>>(result);
                    }
                }
            }
            return View(cookresult);
        }
        /*public IActionResult Index(int EmpId)
        {
            Employee employee = new Employee();
            employee.EmpId = EmpId;
            return View(employee.EmpId);
        }*/
    }
}
