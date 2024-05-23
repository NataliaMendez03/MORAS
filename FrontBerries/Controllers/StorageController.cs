using FrontBerries.Models;
using FrontBerries.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client.Extensions.Msal;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Models;

namespace FrontBerries.Controllers
{
    public class StorageController : Controller
    {
        Uri BaseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public StorageController()
        {
            _client = new HttpClient();
            _client.BaseAddress = BaseAddress;
        }
        [HttpGet]
        public IActionResult StorageGet()
        {
            List<StorageViewModel> storageList = new List<StorageViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/Storage").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                storageList = JsonConvert.DeserializeObject<List<StorageViewModel>>(data);

                // Obtener datos adicionales
                List<Person> person = GetPerson();
                List<Post> post = GetPost();
                List<IdentificationType> typeIdentifications = GetTypeIdentifications();
                List<Quality> quality = GetQuality();
                List<Harvests> harvests = GetHarvests();
                List<Employees> employees = GetEmployees();


                // Mapear datos relacionados
                foreach (var storage in storageList)
                {
                    var harvestInfo = harvests.FirstOrDefault(h => h.IdHarvests == storage.IdHarvests);
                    if (harvestInfo != null)
                    {
                        storage.HarvestDate = harvestInfo.HarvestDate;
                        storage.HarvestAmount = harvestInfo.HarvestAmount;
                    }

                    var employeesInfo = employees.FirstOrDefault(e => e.IdEmployees == harvestInfo.Idemployees);
                    if (employeesInfo != null)
                    {
                        var postInfo = post.FirstOrDefault(p => p.IdPost == employeesInfo.IdPost);
                        if (postInfo != null)
                        {
                            storage.NamePost = postInfo.NamePost;
                        }

                        var personInfo = person.FirstOrDefault(p => p.IdPerson == employeesInfo.IdPerson);
                        if (personInfo != null)
                        {
                            storage.Name = personInfo.Name;
                            storage.LastName = personInfo.LastName;
                            storage.NumberIdentification = personInfo.NumberIdentification;

                            var identificationType = typeIdentifications.FirstOrDefault(ti => ti.IdIdentificationType == personInfo.IdTypeIdentification);
                            if (identificationType != null)
                            {
                                storage.IdentifiType = identificationType.IdentifiType;
                            }
                        }

                        var qualityInfo = quality.FirstOrDefault(q => q.IdQuality == harvestInfo.IdQuality);
                        if (qualityInfo != null)
                        {
                            storage.NQuality = qualityInfo.NQuality;
                            storage.Quantity = qualityInfo.Quantity;
                        }
                    }
                }

            }
            var inactiveLogins = storageList.Where(login => !login.StateDelete).ToList();

            return View(inactiveLogins);
        }
   

        private List<Employees> GetEmployees()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Employees").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Employees>>(data);
            }
            return new List<Employees>();
        }
        private List<Person> GetPerson()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Person").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Person>>(data);
            }
            return new List<Person>();
        }
        private List<Post> GetPost()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Post").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Post>>(data);
            }
            return new List<Post>();
        }
        private List<Harvests> GetHarvests()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Harvests").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Harvests>>(data);
            }
            return new List<Harvests>();
        }
        private List<Quality> GetQuality()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Quality").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Quality>>(data);
            }
            return new List<Quality>();
        }
        private List<IdentificationType> GetTypeIdentifications()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/IdentificationType").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<IdentificationType>>(data);
            }
            return new List<IdentificationType>();
        }




        #region DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                StorageViewModel login = new StorageViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Storage/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<StorageViewModel>(data);
                }
                return View(login);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/Storage/Delete/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Storage details deleted";
                    return RedirectToAction("StorageGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View("StorageGet");

        }
        #endregion
    }
}
