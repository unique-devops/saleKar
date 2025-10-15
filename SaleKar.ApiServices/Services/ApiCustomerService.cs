using SaleKar.Core.Interfaces;
using SaleKar.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SaleKar.ApiServices.Services
{
    public class ApiCustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public ApiCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Customer>>("api/customers")
                ?? new List<Customer>();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Customer>($"api/customers/{id}");
        }

        public async Task AddAsync(Customer customer)
        {
            await _httpClient.PostAsJsonAsync("api/customers", customer);
        }
    }
}
