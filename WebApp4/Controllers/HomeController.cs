using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp4.Models;

namespace WebApp4.Controllers
{

    public class HomeController : Controller
    {
        private readonly Dictionary<string, User> _users = new()
        {
            ["bob"] = new User
            {
                Name = "Bob",
                Age = 40,
                Occupation = "Software Developer",
                Description = "Опытный разработчик"
            },
            ["anna"] = new User
            {
                Name = "Anna",
                Age = 25,
                Occupation = "UX Designer",
                Description = "Креативный дизайнер"
            },
            ["mike"] = new User
            {
                Name = "Mike",
                Age = 35,
                Occupation = "Project Manager",
                Description = "Руководитель проектов с сильными лидерскими качествами"
            }
        };

        public IActionResult Index(string name, string color)
        {
            ViewBag.Color = IsValidColor(color) ? color : "black";

            if (string.IsNullOrEmpty(name))
            {
                ViewBag.Message = "Пожалуйста, укажите параметр name в запросе";
                return View("Message");
            }

            name = name.ToLower();
            if (_users.TryGetValue(name, out User user))
            {
                return View("UserDetails", user);
            }

            ViewBag.Message = $"Пользователь с именем {name} не найден";
            return View("Message");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private bool IsValidColor(string color)
        {
            if (string.IsNullOrEmpty(color)) return false;

            var validColors = new[] { "red", "blue", "green", "black", "purple", "orange" };
            return validColors.Contains(color.ToLower());
        }
    }
}