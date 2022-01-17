using DataShared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace XN_Blazor.Services
{
    public class LoginService
    {
        HttpClient _httpClient;
        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<User> LoginProcess(User input)
        {
            string jsonStr = JsonConvert.SerializeObject(input);
            StringContent content = new StringContent(jsonStr, Encoding.UTF8, MediaTypeNames.Application.Json);

            var result = await _httpClient.PostAsync("api/login", content);
            if (result.IsSuccessStatusCode == false)
            {
                throw new Exception("Fail Login");
            }
            var resultContent = await result.Content.ReadAsStringAsync();
            User resUser = JsonConvert.DeserializeObject<User>(resultContent);

            
            return resUser;
        }
    }
}
