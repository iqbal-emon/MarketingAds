using MarketingAds.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace MarketingAds.Services
{
    public class GetData
    {

        private readonly Uri _baseUrl;



        private readonly HttpClient httpClient;
        public GetData(HttpClient httpClient, Uri baseUrl)
        {
            this.httpClient = httpClient;
            _baseUrl = baseUrl;

        }
        public async Task<IEnumerable<Category>> GetUsers()
        {
             var apiUrl = new Uri(_baseUrl, "api/GetData/Users");
            var dataList = await httpClient.GetFromJsonAsync<IEnumerable<Category>>(apiUrl);
            return dataList;
        }


    }
}
