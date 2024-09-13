using Lr1.Net.Models;
using Lr1.Net.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lr1.Net.Controllers
{
    public class HomeController : Controller
    {
        private readonly CompanyService _companyService;

        public HomeController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            // Отримуємо найбільшу компанію
            var largestCompany = _companyService.GetLargestCompany();

            // Отримуємо особисті дані з JSON
            var personalInfo = _companyService.GetPersonalInfo();

            // Створюємо модель для передачі двох наборів даних на сторінку
            var viewModel = new HomeViewModel
            {
                LargestCompany = largestCompany,
                PersonalInfo = personalInfo
            };

            return View(viewModel);
        }
    }
}

