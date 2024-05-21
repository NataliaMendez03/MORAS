using FrontBerries.Models;
using FrontBerries.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            CreateClientVM createClientVM = new CreateClientVM
            {
                ClientModel = new ClientVM(),
                PersonModel = new PersonVM(),
                ContactModel = new ContactVM(),
                AddressModel = new AddressVM(),
                CityModel = new CityVM(),
                IdentTypeModel = new IdentificationTypeVM(),
                TypeIdentifications = GetTypeIdentificationsSelectList(),
            };     

            return View(createClientVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientVM createClientVM)
        {
            if (!ModelState.IsValid)
            {
                // Repopulate the lists in case of validation error
                createClientVM.TypeIdentifications = GetTypeIdentificationsSelectList();
                return View(createClientVM);
            }
            try
            {
                createClientVM.TypeIdentifications = GetTypeIdentificationsSelectList();
                // Crear Ciudad
                var cityData = JsonConvert.SerializeObject(createClientVM.CityModel);
                var cityContent = new StringContent(cityData, Encoding.UTF8, "application/json");
                var cityResponse = await _client.PostAsync(_client.BaseAddress + $"/City?nameCity={createClientVM.CityModel.NameCity}", cityContent);
                if (!cityResponse.IsSuccessStatusCode)
                {
                    TempData["errorMessage"] = "Error creating address";
                    return View();
                }
                var cityResponseData = await cityResponse.Content.ReadAsStringAsync();
                var createdCity = JsonConvert.DeserializeObject<CityViewModel>(cityResponseData);
                int cityId = createdCity.IdCity;

                // Crear Dirección
                var addressData = JsonConvert.SerializeObject(createClientVM.AddressModel);
                var addressContent = new StringContent(addressData, Encoding.UTF8, "application/json");
                var addressResponse = await _client.PostAsync(_client.BaseAddress + $"/Address?addres={createClientVM.AddressModel.Addres}&idCity={cityId}", addressContent);
                if (!addressResponse.IsSuccessStatusCode)
                {
                    TempData["errorMessage"] = "Error creating address";
                    return View();
                }
                var addressResponseData = await addressResponse.Content.ReadAsStringAsync();
                var createdAddress = JsonConvert.DeserializeObject<AddressViewModel>(addressResponseData);
                int addressId = createdAddress.IdAddress;

                // Crear Contacto
                var contactData = JsonConvert.SerializeObject(createClientVM.ContactModel);
                var contactContent = new StringContent(contactData, Encoding.UTF8, "application/json");
                var contactResponse = await _client.PostAsync(_client.BaseAddress + $"/Contact?phone={createClientVM.ContactModel.Phone}&email={createClientVM.ContactModel.Email}", contactContent);
                if (!contactResponse.IsSuccessStatusCode)
                {
                    TempData["errorMessage"] = "Error creating contact";
                    return View();
                }
                var contactResponseData = await contactResponse.Content.ReadAsStringAsync();
                var createdContact = JsonConvert.DeserializeObject<ContactViewModel>(contactResponseData);
                int contactId = createdContact.IdContact;

                int id = 5;
                int TI = 1;
                // Crear Persona
                createClientVM.PersonModel.IdAddress = addressId;
                createClientVM.PersonModel.IdContact = contactId;
                var personData = JsonConvert.SerializeObject(createClientVM.PersonModel);
                var personContent = new StringContent(personData, Encoding.UTF8, "application/json");
                var personResponse = await _client.PostAsync(_client.BaseAddress + $"/Person?name={createClientVM.PersonModel.Name}&lastName={createClientVM.PersonModel.LastName}" +
                    $"&idContact={contactId}&idTypeIdentification={TI}&numberIdentification={createClientVM.PersonModel.NumberIdentification}" +
                    $"&idAddress={addressId}", personContent);

                if (!personResponse.IsSuccessStatusCode)
                {
                    TempData["errorMessage"] = "Error creating person";
                    return View();
                }
                var personResponseData = await personResponse.Content.ReadAsStringAsync();
                var createdPerson = JsonConvert.DeserializeObject<PersonViewModel>(personResponseData);
                int personId = createdPerson.IdPerson;

                // Crear Cliente
                //createClientVM.ClientModel.IdPerson = personId;
                var clientData = JsonConvert.SerializeObject(createClientVM.ClientModel);
                var clientContent = new StringContent(clientData, Encoding.UTF8, "application/json");
                var clientResponse = await _client.PostAsync(_client.BaseAddress + $"/Client?idPerson={personId}", clientContent);
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

        private List<SelectListItem> GetTypeIdentificationsSelectList()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/IdentificationType").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var typeIdentifications = JsonConvert.DeserializeObject<List<IdentificationType>>(data);
                return typeIdentifications.Select(ti => new SelectListItem
                {
                    Value = ti.IdIdentificationType.ToString(),
                    Text = ti.IdentifiType
                }).ToList();
            }
            return new List<SelectListItem>();
        }

        #endregion
    }

}






