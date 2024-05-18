using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using FrontBerries.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace FrontBerries.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        public IActionResult SystemLogin()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            //if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }
    }
}
    
