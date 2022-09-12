using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Core.Model;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Rest
{
    public class RestService : IRestService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _http;
        public RestService(IConfiguration configuration, IHttpContextAccessor http)
        {
            _configuration = configuration;
            _http = http;
        }
        public async Task<BaseResponse<T>> Get<T>(string url)
        {
            try
            {
                using (var clint = new HttpClient())
                {
                    string token = await GetToken();
                    if (!string.IsNullOrEmpty(token))
                    {
                        clint.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }


                    var uri = new Uri(_configuration["BaseUrl"]);
                    var response = await clint.GetAsync($"{uri}{url}");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<BaseResponse<T>>(responseString);
                    }
                    return new BaseResponse<T>().Fail("Servise bağlanırken hata oluştu");
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<T>().Fail(e.Message);
            }

        }

        public async Task<BaseResponse<T>> Post<T>(string url, object data)
        {
            try
            {
                using (var clint = new HttpClient())
                {
                    if (url != "auth/login")
                    {
                        string token = await GetToken();
                        if (!string.IsNullOrEmpty(token))
                        {
                            clint.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        }
                    }
                   

                    StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    var uri = new Uri(_configuration["BaseUrl"]);
                    var response = await clint.PostAsync($"{uri}{url}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<BaseResponse<T>>(responseString);
                    }
                    return new BaseResponse<T>().Fail("Servise bağlanırken hata oluştu");
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<T>().Fail(e.Message);
            }
        }
        //token kontrolü yapılıyor
        private async Task<string> GetToken()
        {
            var user = new User { Username = "omer.karikutal", Password = "12345" };
            string token = string.Empty;

            if (_http.HttpContext.Session.GetString("token") == null)
            {
                var tkn = await CreteToken(user);

                if (tkn.Status)
                    token = tkn.Data;
                _http.HttpContext.Session.SetString("token", token);
            }
            else
            {
                var sessionToken = _http.HttpContext.Session.GetString("token");

                var jwtToken = new JwtSecurityToken(sessionToken);

                if (jwtToken == null || jwtToken.ValidFrom > DateTime.UtcNow || jwtToken.ValidTo < DateTime.UtcNow)
                {
                    var tkn = await CreteToken(user);

                    if (tkn.Status)
                        token = tkn.Data;
                    _http.HttpContext.Session.SetString("token", token);
                }
                else
                {
                    token = sessionToken;
                }
            }


            return token;
        }
        private async Task<BaseResponse<string>> CreteToken(User user)
        {
            return await Post<string>($"auth/login", user);
        }
    }
}
