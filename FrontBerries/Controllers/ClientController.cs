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
        public async Task<IActionResult> Create(ClientViewModel clientModel, PersonViewModel personModel, ContactViewModel contactModel, AddressViewModel addressModel)
        {
            try
            {
                // Crear Dirección
                var addressData = JsonConvert.SerializeObject(addressModel);
                var addressContent = new StringContent(addressData, Encoding.UTF8, "application/json");
                var addressResponse = await _client.PostAsync(_client.BaseAddress + $"/Address?addres={addressModel.Addres}&idCity={5}", addressContent);
                if (!addressResponse.IsSuccessStatusCode)
                {
                    TempData["errorMessage"] = "Error creating address";
                    return View();
                }
                var addressResponseData = await addressResponse.Content.ReadAsStringAsync();
                var createdAddress = JsonConvert.DeserializeObject<AddressViewModel>(addressResponseData);
                int addressId = createdAddress.IdAddress;

                // Crear Contacto
                var contactData = JsonConvert.SerializeObject(contactModel);
                var contactContent = new StringContent(contactData, Encoding.UTF8, "application/json");
                var contactResponse = await _client.PostAsync(_client.BaseAddress + $"/Contact?phone={contactModel.Phone}&email={contactModel.Email}", contactContent);
                if (!contactResponse.IsSuccessStatusCode)
                {
                    TempData["errorMessage"] = "Error creating contact";
                    return View();
                }
                var contactResponseData = await contactResponse.Content.ReadAsStringAsync();
                var createdContact = JsonConvert.DeserializeObject<ContactViewModel>(contactResponseData);
                int contactId = createdContact.IdContact;

                // Crear Persona
                //personModel.IdAddress = addressId;
                personModel.IdContact = contactId;
                var personData = JsonConvert.SerializeObject(personModel);
                var personContent = new StringContent(personData, Encoding.UTF8, "application/json");
                var personResponse = await _client.PostAsync(_client.BaseAddress + $"/Person?name={personModel.Name}&lastName={personModel.LastName}" +
                    $"&idContact={personModel.IdContact}&idTypeIdentification={personModel.IdTypeIdentification}&numberIdentification={personModel.NumberIdentification}" +
                    $"&idAddress={20}", personContent);

                if (!personResponse.IsSuccessStatusCode)
                {
                    TempData["errorMessage"] = "Error creating person";
                    return View();
                }
                var personResponseData = await personResponse.Content.ReadAsStringAsync();
                var createdPerson = JsonConvert.DeserializeObject<PersonViewModel>(personResponseData);
                int personId = createdPerson.IdPerson;

                // Crear Cliente
                clientModel.IdPerson = personId;
                var clientData = JsonConvert.SerializeObject(clientModel);
                var clientContent = new StringContent(clientData, Encoding.UTF8, "application/json");
                var clientResponse = await _client.PostAsync(_client.BaseAddress + $"/Client?idPerson={clientModel.IdPerson}", clientContent);
                if (!clientResponse.IsSuccessStatusCode)
                {
                    TempData["errorMessage"] = "Error creating client";
                    return View();
                }

                TempData["successMessage"] = "Client created successfully";
                return RedirectToAction("ClientGet");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        #endregion
    }

}






