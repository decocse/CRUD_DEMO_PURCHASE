using CRUD_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CRUD_MVC.Controllers
{
    public class PurchaseController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7202/api");
        private readonly HttpClient _httpClient;

        public PurchaseController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;  
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Purchase>purchaselist = new List<Purchase>();
            HttpResponseMessage response= _httpClient.GetAsync(_httpClient.BaseAddress + "/purchases/GetPurchases").Result;
            Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                string data=response.Content.ReadAsStringAsync().Result;
                purchaselist = JsonConvert.DeserializeObject<List<Purchase>>(data);
            }
            return View(purchaselist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Purchase purchase)
        {
            try
            {
                string data = JsonConvert.SerializeObject(purchase);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/purchases/PostPurchase", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Privacy");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try 
            { 
            Purchase purchase = new Purchase();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/purchases/GetPurchase/"+id).Result;
            
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    purchase = JsonConvert.DeserializeObject<Purchase>(data);
                }
                return View(purchase);
            }
            catch(Exception ex) 
            {

                return View(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Edit(Purchase model) 
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                string idmp = model.ID.ToString();
                HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/Purchases/PutPurchase/" + model.ID, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch 
            {
                Console.WriteLine(model.ID);
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            try
            {
                Purchase purchase = new Purchase();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/purchases/GetPurchase/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    purchase = JsonConvert.DeserializeObject<Purchase>(data);
                }
                return View(purchase);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }

        }
        [HttpPost]
        public IActionResult Delete(Purchase model) 
        {
            try
            {
               // string data = JsonConvert.SerializeObject(model);
                //StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                //string idmp = model.ID.ToString();
                HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/Purchases/DeletePurchase/" + model.ID).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
            return View();
        }


    }
}
