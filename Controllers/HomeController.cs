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
            var largestCompany = _companyService.GetLargestCompany();

            var personalInfo = _companyService.GetPersonalInfo();

            var viewModel = new HomeViewModel
            {
                LargestCompany = largestCompany,
                PersonalInfo = personalInfo
            };

            return View(viewModel);
        }
    }
}

