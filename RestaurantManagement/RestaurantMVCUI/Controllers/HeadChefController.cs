using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestaurantEntity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMVCUI.Controllers
{
    public class HeadChefController : Controller
    {
        private IConfiguration _configuration;

        public HeadChefController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<Order> orderResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Order/GetOrders";

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        orderResult = JsonConvert.DeserializeObject<IEnumerable<Order>>(result);
                    }
                }
            }
            return View(orderResult);
        }

        public async Task<IActionResult> Speciality(int OrderId)
        { //IEnumerable<Order> order;
            Order order = null;


            /*
                        TempData["foodname"]=order.Food.FoodName;
                        TempData.Keep();*/

            //Food food = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Order/GetOrderById?orderId=" + OrderId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        order = JsonConvert.DeserializeObject<Order>(result);
                    }
                }
            }
            return View(order);
        }


        [HttpPost]
        public async Task<IActionResult> Speciality(Order order)
        {
           

          
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Order/GetOrderById?orderId=" + order.OrderId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        order = JsonConvert.DeserializeObject<Order>(result);
                    }
                }
            }

            Cook cook = new Cook();

            cook.EmpId = Convert.ToInt32(TempData["chefid"]);
            TempData.Keep();
            cook.Quantity = order.Quantity;
            cook.FoodId = order.FoodId;
            cook.Speciality = TempData["speciality"].ToString();
            TempData.Keep();
            cook.CookStatus = true;

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Cook/AddCook";

                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        ViewBag.status = "Ok";
                        ViewBag.message = "Cooking Strted Successfull!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }



        public async Task<IActionResult> Assign(int OrderId)
        {


            IEnumerable<Employee> employeeList = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Employee/GetEmployees";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result1 = await response.Content.ReadAsStringAsync();
                        employeeList = JsonConvert.DeserializeObject<IEnumerable<Employee>>(result1);
                    }
                }
            }
            /*TempData["foodcost1"] = Convert.ToInt32(food.FoodCost);
            TempData.Keep();*/

            return View(employeeList);
        }


        public async Task<IActionResult> cheflist(int OrderId)
        {
            Order order = new Order();
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Order/GetOrderById?orderId=" + OrderId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        order = JsonConvert.DeserializeObject<Order>(result);
                    }
                }
            }
            TempData["OrderIdforAssign"] = OrderId;
            TempData.Keep();
            IEnumerable<Employee> employeeresult = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "Employee/GetEmployees";//api controller name and httppost name given inside httppost in moviecontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        employeeresult = JsonConvert.DeserializeObject<IEnumerable<Employee>>(result);
                    }



                }
            }
            List<Employee> employeeresultchef = new List<Employee>();

            foreach(var item in employeeresult)
            { if(item.EmpDesignation=="CHEF"&&item.EmpSpeciality==order.Food.FoodCuisine)
                employeeresultchef.Add(item);
            }
            return View(employeeresultchef);
        }
    }
}
