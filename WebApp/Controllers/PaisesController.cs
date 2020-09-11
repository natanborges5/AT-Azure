using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using WebApp.ApiServices;
using WebApp.Models.Paises;

namespace WebApp.Controllers
{
    public class PaisesController : Controller
    {
        private readonly IPaisesApi _paisesApi;

        public PaisesController(IPaisesApi paisesApi)
        {
            _paisesApi = paisesApi;
        }

        // GET: PaisesController
        public async Task<ActionResult> Index()
        {
            var paises = await _paisesApi.GetAsync();

            return View(paises);
        }

        // GET: PaisesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaisesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaisesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CriarPaisViewModel criarPaisViewModel )
        {
            var URLFoto =  UploadFotoPais(criarPaisViewModel.fotoPais);
            criarPaisViewModel.urlFoto = URLFoto;
            await _paisesApi.PostAsync(criarPaisViewModel);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        

        // GET: PaisesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaisesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaisesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaisesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private string UploadFotoPais(IFormFile fotoPais)
        {
            

            var reader = fotoPais.OpenReadStream();
            var cloudStorageAccount = Microsoft.Azure.Storage.CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=atazure;AccountKey=kYFNYaj+czoH0m4kgp/jg+BogNCCsMBR33ls6mKZlRqGi/3rzxNNtXQeuaCt8MGhy3tcbhz/AWPrxhQA8E7DzQ==;EndpointSuffix=core.windows.net");
            var blobClient = cloudStorageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("bandeirapaises");
            container.CreateIfNotExists();
            var blob = container.GetBlockBlobReference(Guid.NewGuid().ToString());
            blob.UploadFromStream(reader);
            var destinoDaImagemNaNuvem = blob.Uri.ToString();
            return destinoDaImagemNaNuvem;
        }
    }
}
