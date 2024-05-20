using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Models;
using System.Text;

namespace FrontBerries.Controllers
{
    public class ClientController : Controller
    {
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public ClientController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

    #region GetClient
        [HttpGet]
        public IActionResult ClientGet()
        {
            List<ClientViewModel> Loginlist = new List<ClientViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/Client").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Loginlist = JsonConvert.DeserializeObject<List<ClientViewModel>>(data);

                // Obtener datos adicionales
                List<Person> person = GetPerson();
                List<IdentificationType> typeIdentifications = GetTypeIdentifications();

                // Mapear datos relacionados
                foreach (var client in Loginlist)
                {
                    client.Name = person.FirstOrDefault(p => p.IdPerson == client.IdPerson)?.Name;
                    client.LastName = person.FirstOrDefault(p => p.IdPerson == client.IdPerson)?.LastName;
                    client.NumberIdentification = person.FirstOrDefault(ni => ni.IdPerson == client.IdPerson).NumberIdentification;

                    var personInfo = person.FirstOrDefault(p => p.IdPerson == client.IdPerson);
                    if (personInfo != null)
                    {
                        var identificationType = typeIdentifications.FirstOrDefault(ti => ti.IdIdentificationType == personInfo.IdTypeIdentification);
                        if (identificationType != null)
                        {
                            client.IdentifiType = identificationType.IdentifiType;
                        }
                    }
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
        #endregion

        #region CreateClient
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientViewModel client, Person person, Contact contact, Address address)
        {
            if (ModelState.IsValid)
            {
                // Crear la persona
                string personData = JsonConvert.SerializeObject(person);
                StringContent personContent = new StringContent(personData, Encoding.UTF8, "application/json");
                HttpResponseMessage personResponse = _client.PostAsync(_client.BaseAddress + "/Person", personContent).Result;
                if (!personResponse.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Error al crear la persona. Por favor contacte al administrador.");
                    ViewBag.IdentificationTypes = GetTypeIdentifications();
                    return View(client);
                }
                person = JsonConvert.DeserializeObject<Person>(personResponse.Content.ReadAsStringAsync().Result);

                // Crear el cliente
                client.IdPerson = person.IdPerson;
                string clientData = JsonConvert.SerializeObject(client);
                StringContent clientContent = new StringContent(clientData, Encoding.UTF8, "application/json");
                HttpResponseMessage clientResponse = _client.PostAsync(_client.BaseAddress + "/Client", clientContent).Result;
                if (!clientResponse.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el cliente. Por favor contacte al administrador.");
                    ViewBag.IdentificationTypes = GetTypeIdentifications();
                    return View(client);
                }

                // Crear el contacto
                contact.IdContact = person.IdContact;
                string contactData = JsonConvert.SerializeObject(contact);
                StringContent contactContent = new StringContent(contactData, Encoding.UTF8, "application/json");
                HttpResponseMessage contactResponse = _client.PostAsync(_client.BaseAddress + "/Contact", contactContent).Result;
                if (!contactResponse.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el contacto. Por favor contacte al administrador.");
                    ViewBag.IdentificationTypes = GetTypeIdentifications();
                    return View(client);
                }

                // Crear la dirección
                address.IdAddress = person.IdAddress;
                string addressData = JsonConvert.SerializeObject(address);
                StringContent addressContent = new StringContent(addressData, Encoding.UTF8, "application/json");
                HttpResponseMessage addressResponse = _client.PostAsync(_client.BaseAddress + "/Address", addressContent).Result;
                if (!addressResponse.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Error al crear la dirección. Por favor contacte al administrador.");
                    ViewBag.IdentificationTypes = GetTypeIdentifications();
                    return View(client);
                }

                return RedirectToAction("ClientGet");
            }

            // Optional: Reload additional data for dropdowns, etc. in case of error
            ViewBag.IdentificationTypes = GetTypeIdentifications();
            return View(client);
        }
        #endregion
    }

}



