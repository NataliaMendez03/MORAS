using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Models;
using System.Reflection;
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


        #region GetClient
        [HttpGet]
        public IActionResult BillSaleGet()
        {
            List<BillSaleViewModel> Loginlist = new List<BillSaleViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/BillSale").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Loginlist = JsonConvert.DeserializeObject<List<BillSaleViewModel>>(data);

                List<Client> client = GetClient();
                List<SalesDetails> salesDetails = GetSalesDetails();
                List<Person> person = GetPerson();
                List<Contact> contacts = GetContacts();
                List<IdentificationType> typeIdentifications = GetTypeIdentifications();
                List<Address> addresses = GetAddresses();

                foreach (var billSale in Loginlist)
                {
                    billSale.Amount = salesDetails.FirstOrDefault(p => p.IdSalesDetails == billSale.IdSalesDetails)?.Amount;
                    billSale.SalePrice = salesDetails.FirstOrDefault(p => p.IdSalesDetails == billSale.IdSalesDetails)?.SalePrice;

                    var clientInfo = client.FirstOrDefault(p => p.IdClient == billSale.IdClient);
                    var personInfo = person.FirstOrDefault(p => p.IdPerson == clientInfo.IdPerson);

                    if (clientInfo != null || personInfo != null)
                    {
                        var name = person.FirstOrDefault(ti => ti.IdPerson == clientInfo.IdPerson);
                        var lastName = person.FirstOrDefault(ti => ti.IdPerson == clientInfo.IdPerson);
                        var numIdent = person.FirstOrDefault(ti => ti.IdPerson == clientInfo.IdPerson);
                        var identificationType = typeIdentifications.FirstOrDefault(p => p.IdIdentificationType == personInfo.IdTypeIdentification);
                        var email = contacts.FirstOrDefault(ti => ti.IdContact == personInfo.IdContact);
                        var phone = contacts.FirstOrDefault(ti => ti.IdContact == personInfo.IdContact);
                        var address = addresses.FirstOrDefault(ti => ti.IdAddress == personInfo.IdAddress);

                        if (name != null || lastName != null || numIdent != null || identificationType != null || email != null || phone != null || address != null)
                        {
                            billSale.Name = name.Name;
                            billSale.LastName = lastName.LastName;
                            billSale.IdentifiType = identificationType.IdentifiType;
                            billSale.NumberIdentification = numIdent.NumberIdentification;
                            billSale.Email = email.Email;
                            billSale.Phone = phone.Phone;
                            billSale.Address = address.Addres;
                        }
                    }
                }


            }
            var inactiveLogins = Loginlist.Where(login => !login.StateDeleted).ToList();

            return View(inactiveLogins);
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
        private List<Contact> GetContacts()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Contact").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Contact>>(data);
            }
            return new List<Contact>();
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
        private List<Address> GetAddresses()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Address").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Address>>(data);
            }
            return new List<Address>();
        }
        #endregion




    }
}
