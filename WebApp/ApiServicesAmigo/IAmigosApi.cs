using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Amigo;


namespace WebApp.ApiServices
{
    public interface IAmigosApi
    {
        Task<CriarAmigoViewModel> PostAsync(CriarAmigoViewModel criarAmigoViewModel);
        Task<List<ListarAmigoViewModel>> GetAsync();
        Task<ListarAmigoViewModel> GetAsync(string id);
        Task<ListarAmigoViewModel> DeleteAsync(string id);
    }

}
