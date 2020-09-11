using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Paises;

namespace WebApp.ApiServices
{
    public interface IPaisesApi
    {
        Task<CriarPaisViewModel> PostAsync(CriarPaisViewModel criarPaisViewModel);
        Task<List<ListarPaisViewModel>> GetAsync();
    }

}
