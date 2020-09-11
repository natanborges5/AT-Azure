using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models.Paises;
using System.Web;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System;
using System.Net;

namespace WebApp.ApiServices
{
    public class PaisesApi : IPaisesApi
    {
        private readonly HttpClient _httpClient;


        public PaisesApi()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.BaseAddress = new Uri("http://localhost:59856/");
        }

        public async Task<CriarPaisViewModel>  PostAsync(CriarPaisViewModel criarPaisViewModel)
        {
            var criarPaisViewModelJson = JsonConvert.SerializeObject(criarPaisViewModel);


            

            var conteudo = new StringContent(criarPaisViewModelJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Paises", conteudo);

            if (response.IsSuccessStatusCode)
            {
                return criarPaisViewModel;
            }
            else if(response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var erros = JsonConvert.DeserializeObject<List<string>>(responseContent);
                criarPaisViewModel.Erros = erros;

                return criarPaisViewModel;
            }
            return criarPaisViewModel;
        }
        public async Task<List<ListarPaisViewModel>> GetAsync()
        {
            var response = await _httpClient.GetAsync("api/Paises");

            var responseContent = await response.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<ListarPaisViewModel>>(responseContent);
            return list;

        }
    }

}
