using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Models;
using System.Text;

namespace FrontBerries.Controllers
{
    public class EmployeesController : Controller
    {
        Uri BaseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public EmployeesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = BaseAddress;
        }
        [HttpGet]
        public IActionResult EmployeesGet()
        {
            List<EmployeesViewModel> Loginlist = new List<EmployeesViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/Employees").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Loginlist = JsonConvert.DeserializeObject<List<EmployeesViewModel>>(data);

                // Obtener datos adicionales
                List<Person> person = GetPerson();
                List<Post> post = GetPost();
                List<IdentificationType> typeIdentifications = GetTypeIdentifications();


                // Mapear datos relacionados
                foreach (var employees in Loginlist)
                {
                    employees.NamePost = post.FirstOrDefault(c => c.IdPost == employees.IdPost)?.NamePost;
                    employees.Name = person.FirstOrDefault(p => p.IdPerson == employees.IdPerson)?.Name;
                    employees.LastName = person.FirstOrDefault(p => p.IdPerson == employees.IdPerson)?.LastName;
                    employees.IdentifiType = typeIdentifications.FirstOrDefault(ti => ti.IdIdentificationType == employees.IdTypeIdentification)?.IdentifiType;
                    employees.NumberIdentification = person.FirstOrDefault(ni => ni.IdPerson == employees.IdPerson).NumberIdentification;
                }
            }
            var inactiveLogins = Loginlist.Where(login => !login.StateDelete).ToList();

            return View(inactiveLogins);
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

        ///-///////////---------------------------------------------------------------------------------------------------------------------/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeesViewModel model)
        {
            try
            {
                String data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/Employees/Create?idPost={model.IdPost}&idPerson={model.IdPerson}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Employees Created";
                    return RedirectToAction("EmployeesGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                EmployeesViewModel login = new EmployeesViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Employees/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<EmployeesViewModel>(data);
                }
                return View(login);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }
        [HttpPost]
        public IActionResult Update(EmployeesViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + $"/Employees/Update/{model.IdEmployees}?idPost={model.IdPost}&idPerson={model.IdPerson}\"", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Employees details updated";
                    return RedirectToAction("EmployeesGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                EmployeesViewModel login = new EmployeesViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Employees/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<EmployeesViewModel>(data);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/Employees/Delete/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "User details deleted";
                    return RedirectToAction("EmployeesGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View("EmployeesGet");

        }
    }
}
