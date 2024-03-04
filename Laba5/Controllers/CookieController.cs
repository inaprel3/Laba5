// Controllers/CookieController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace Laba5.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveToCookie(string value, string dateTimeString)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(dateTimeString))
            {
                return RedirectToAction("Index", "Home");
            }

            DateTime dateTime;
            if (DateTime.TryParse(dateTimeString, out dateTime))
            {
                Response.Cookies.Append("MyCookie", value, new CookieOptions
                {
                    Expires = dateTime
                });
            }
            else
            {
                Response.Cookies.Append("MyCookie", value, new CookieOptions
                {
                    Expires = DateTime.MaxValue
                });
            }

            ViewBag.Message = "Data saved successfully!";

            return RedirectToAction("DisplayCookieValue");
        }

        public IActionResult DisplayCookieValue()
        {
            var value = Request.Cookies["MyCookie"];
            ViewBag.CookieValue = value ?? "No data found in cookie";

            return View();
        }
    }
}