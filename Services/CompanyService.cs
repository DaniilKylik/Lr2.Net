using Lr1.Net.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Lr1.Net.Services
{
    public class CompanyService
    {
        private readonly IConfiguration _configuration;

        public CompanyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetLargestCompany()
        {
            var companies = new List<(string Name, int Employees)>
        {
            ("Microsoft", GetEmployeeCount("Microsoft")),
            ("Apple", GetEmployeeCount("Apple")),
            ("Google", GetEmployeeCount("Google"))
        };

            var largestCompany = companies.OrderByDescending(c => c.Employees).First();
            return largestCompany.Name;
        }

        private int GetEmployeeCount(string companyName)
        {
            return _configuration.GetValue<int>($"Companies:{companyName}:Employees");
        }
        // Метод для десеріалізації JSON-файлу з інформацією про вас
        public PersonalInfo GetPersonalInfo()
        {
            var jsonString = File.ReadAllText("Config/personal.json");
            var personalInfo = JsonSerializer.Deserialize<PersonalInfo>(jsonString);
            return personalInfo;
        }
    }

}
