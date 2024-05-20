using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Models;
using System.Text;

namespace FrontBerries.Controllers
{
    public class BillSaleController : Controller
    {
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public BillSaleController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult BillSaleGet()
        {
            List<BillSaleViewModel> billSaleList = new List<BillSaleViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/BillSale").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                billSaleList = JsonConvert.DeserializeObject<List<BillSaleViewModel>>(data);

                // Obtener datos adicionales
                List<Client> Client = GetClient();
                List<PersonViewModel> persons = GetPersons();
                List<SalesDetails> salesDetails = GetSalesDetails();

                // Mapear datos relacionados
                foreach (var billSale in billSaleList)
                {
                    var client = Client.FirstOrDefault(c => c.IdClient == billSale.IdClient);
                    if (client != null)
                    {
                        var person = persons.FirstOrDefault(p => p.IdPerson == client.IdPerson);
                        if (person != null)
                        {
                            billSale.ClientName = $"{person.Name} {person.LastName}";
                        }
                    }

                    var salesDetail = salesDetails.FirstOrDefault(sd => sd.IdSalesDetails == billSale.IdSalesDetails);
                    if (salesDetail != null)
                    {
                        //billSale.Amount = salesDetails.Amount;
                        //billSale.SalePrice = salesDetails.SalePrice;
                    }
                }
            }
            //var activeBillSales = billSaleList.Where(bill => !billSale.StateDeleted).ToList();

            return View(/*activeBillSales*/);
        }

        private List<Client> GetClient()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Client").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Client>>(data);
            }
            return new List<Client>();
        }

        private List<PersonViewModel> GetPersons()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Person").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<PersonViewModel>>(data);
            }
            return new List<PersonViewModel>();
        }

        private List<SalesDetails> GetSalesDetails()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/SalesDetails").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<SalesDetails>>(data);
            }
            return new List<SalesDetails>();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new BillSaleViewModel
            {
                Client = GetClientSelectList(),
                SalesDetails = GetSalesDetailsSelectList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BillSaleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Client = GetClientSelectList();
                model.SalesDetails = GetSalesDetailsSelectList();
                return View(model);
            }
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/BillSale?IdClient={model.IdClient}&DateSale={model.DateSale}&IdSalesDetails={model.IdSalesDetails}&Notes={model.Notes}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Bill Sale Created";
                    return RedirectToAction("BillSaleGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }

            model.Client = GetClientSelectList();
            model.SalesDetails = GetSalesDetailsSelectList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                BillSaleViewModel billSale = new BillSaleViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/BillSale/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    billSale = JsonConvert.DeserializeObject<BillSaleViewModel>(data);
                }
                billSale.Client = GetClientSelectList();
                billSale.SalesDetails = GetSalesDetailsSelectList();
                return View(billSale);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Update(BillSaleViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + $"/BillSale/Update/{model.IdBillSale}?IdClient={model.IdClient}&DateSale={model.DateSale}&IdSalesDetails={model.IdSalesDetails}&Notes={model.Notes}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Bill Sale updated";
                    return RedirectToAction("BillSaleGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }
            model.Client = GetClientSelectList();
            model.SalesDetails = GetSalesDetailsSelectList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                BillSaleViewModel billSale = new BillSaleViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/BillSale/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    billSale = JsonConvert.DeserializeObject<BillSaleViewModel>(data);
                }
                return View(billSale);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/BillSale/Delete/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Bill Sale deleted";
                    return RedirectToAction("BillSaleGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View("BillSaleGet");
        }

        private List<SelectListItem> GetClientSelectList()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Client").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var Client = JsonConvert.DeserializeObject<List<Client>>(data);
                return Client.Select(c => new SelectListItem
                {
                    Value = c.IdClient.ToString(),
                    Text = c.IdClient.ToString() // Aquí podrías personalizar para mostrar más detalles del cliente
                }).ToList();
            }
            return new List<SelectListItem>();
        }

        private List<SelectListItem> GetSalesDetailsSelectList()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/SalesDetails").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var salesDetails = JsonConvert.DeserializeObject<List<SalesDetails>>(data);
                return salesDetails.Select(sd => new SelectListItem
                {
                    Value = sd.IdSalesDetails.ToString(),
                    Text = $"Amount: {sd.Amount}, Price: {sd.SalePrice}" // Aquí podrías personalizar para mostrar más detalles de la venta
                }).ToList();
            }
            return new List<SelectListItem>();
        }
    }
}
