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
    public class ApiItemService : IItemService
    {
        private readonly HttpClient _httpClient;

        public ApiItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResponse<List<Item>>>("api/item");
            if (result.is_success)
            {
                return result.data;
            }
            else
            {
                return new List<Item>();
            }
             
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Item>($"api/item/{id}");
        }
       
    }
}
