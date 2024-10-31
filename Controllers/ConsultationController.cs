using Microsoft.AspNetCore.Mvc;
using lr10.Models;

namespace lr10.Controllers
{
    public class ConsultationController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(ConsultationRequest request)
        {
            if (ModelState.IsValid)
            {
                if (request.SelectedProduct == "Основи" && request.ConsultationDate.DayOfWeek == DayOfWeek.Monday)
                {
                    ModelState.AddModelError("ConsultationDate", "Консультація щодо 'Основи' не може проходити по понеділках.");
                    return View(request);
                }

                // Передача даних в метод Success для відображення у в'юсі
                return RedirectToAction("Success", new
                {
                    fullName = request.FullName,
                    selectedProduct = request.SelectedProduct,
                    consultationDate = request.ConsultationDate
                });
            }

            // Якщо є помилки, повертаємо форму з помилками
            return View(request);
        }


        public IActionResult Success(string fullName, string selectedProduct, DateTime consultationDate)
        {
            ViewData["FullName"] = fullName;
            ViewData["SelectedProduct"] = selectedProduct;
            ViewData["ConsultationDate"] = consultationDate.ToString("dd.MM.yyyy");
            return View();
        }

    }
}
