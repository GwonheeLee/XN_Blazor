using DataShared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace XN_Blazor.Services
{
    public static class BarChartService
    {
        public static string[] GetChartX(DateTime start, DateTime end)
        {
            string[] days = new string[(end - start).Days];

            for (int i = 0; i < days.Length; i++)
            {
                days[i] = start.AddDays(i).Day.ToString();
            }
            return days;
        }
    }
    public class ItemService 
    {
        HttpClient _httpClient;
        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
        }
        public async Task<List<Item>> GetItemsAsync() 
        {
            var results = await _httpClient.GetAsync("api/item");

            if (results.IsSuccessStatusCode == false)
            {
                throw new Exception("GetItems Falied");
            }
            var resultContent = await results.Content.ReadAsStringAsync();

            List<Item> resGameResults = JsonConvert.DeserializeObject<List<Item>>(resultContent);
            return resGameResults;
        }
        public async Task<Bad_Good> GetDefect(Bad_Good input)
        {
            string jsonStr = JsonConvert.SerializeObject(input);
            StringContent content = new StringContent(jsonStr, Encoding.UTF8, MediaTypeNames.Application.Json);

            var result = await _httpClient.PostAsync("api/item/defect", content);

            if (result.IsSuccessStatusCode == false)
                throw new Exception("Fail GetDefect");

            var resultContent = await result.Content.ReadAsStringAsync();
            var resBad_Good = JsonConvert.DeserializeObject<Bad_Good>(resultContent);

            return resBad_Good;
        }
        public async Task<double[]> GetItemQty(ItemQty input)
        {
            string jsonStr = JsonConvert.SerializeObject(input);
            StringContent content = new StringContent(jsonStr, Encoding.UTF8, MediaTypeNames.Application.Json);

            var result = await _httpClient.PostAsync("api/item/itemQty",content);

            if (result.IsSuccessStatusCode == false)
                throw new Exception("Fail GetItemQty");

            var resultContent = await result.Content.ReadAsStringAsync();
            var resItemQty = JsonConvert.DeserializeObject<double[]>(resultContent);

            return resItemQty;
        }

    }

}
