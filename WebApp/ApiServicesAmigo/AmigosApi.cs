using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Amigo;

namespace WebApp.ApiServices
{
    public class AmigosApi : IAmigosApi
    {
        private readonly HttpClient _httpClient;


        public AmigosApi()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.BaseAddress = new Uri("http://localhost:59854/");
        }

        public async Task<CriarAmigoViewModel>  PostAsync(CriarAmigoViewModel criarAmigoViewModel)
        {
            var criarAmigoViewModelJson = JsonConvert.SerializeObject(criarAmigoViewModel);

            var conteudo = new StringContent(criarAmigoViewModelJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Amigos", conteudo);

            if (response.IsSuccessStatusCode)
            {
                return criarAmigoViewModel;
            }
            else if(response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var erros = JsonConvert.DeserializeObject<List<string>>(responseContent);
                criarAmigoViewModel.Erros = erros;

                return criarAmigoViewModel;
            }
            return criarAmigoViewModel;
        }
        public async Task<List<ListarAmigoViewModel>> GetAsync()
        {
            var response = await _httpClient.GetAsync("api/Amigos");

            var responseContent = await response.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<ListarAmigoViewModel>>(responseContent);
            return list;

        }
        public async Task<ListarAmigoViewModel> GetAsync(string id)
        {
            var response = await _httpClient.GetAsync("api/Amigos/" + id);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ListarAmigoViewModel>(responseContent);

        }
        public async Task<ListarAmigoViewModel> DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync("api/Amigos/" + id);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ListarAmigoViewModel>(responseContent);

        }
    }

}
