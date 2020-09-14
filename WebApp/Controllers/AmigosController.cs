using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Blob;
using WebApp.ApiServices;
using WebApp.Models.Amigo;

namespace WebApp.Controllers
{
    public class AmigosController : Controller
    {
        private readonly IAmigosApi _amigosApi;

        public AmigosController(IAmigosApi amigosApi)
        {
            _amigosApi = amigosApi;
        }

        // GET: PaisesController
        public async Task<ActionResult> Index()
        {
            var paises = await _amigosApi.GetAsync();

            return View(paises);
        }

        // GET: PaisesController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var viewModel = await _amigosApi.GetAsync(id);

            return View(viewModel);
        }

        // GET: PaisesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaisesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CriarAmigoViewModel criarAmigoViewModel)
        {
            var URLFoto = UploadFotoPais(criarAmigoViewModel.fotoAmigo);
            criarAmigoViewModel.urlFoto = URLFoto;
            await _amigosApi.PostAsync(criarAmigoViewModel);

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
        public async Task<ActionResult> Edit(string id)
        {
            var viewModel = await _amigosApi.GetAsync(id);

            return View(viewModel);
        }

        // POST: PaisesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditarAmigoViewModel editarAmigoViewModel)
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
        public async Task<ActionResult> Delete(string id)
        {
            var viewModel = await _amigosApi.GetAsync(id);

            return View(viewModel);
        }

        // POST: PaisesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, DeletarAmigoViewModel deletarAmigoViewModel)
        {
            await _amigosApi.DeleteAsync(id);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private string UploadFotoPais(IFormFile fotoAmigo)
        {


            var reader = fotoAmigo.OpenReadStream();
            var cloudStorageAccount = Microsoft.Azure.Storage.CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=atazure;AccountKey=kYFNYaj+czoH0m4kgp/jg+BogNCCsMBR33ls6mKZlRqGi/3rzxNNtXQeuaCt8MGhy3tcbhz/AWPrxhQA8E7DzQ==;EndpointSuffix=core.windows.net");
            var blobClient = cloudStorageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("fotoperfil");
            container.CreateIfNotExists();
            var blob = container.GetBlockBlobReference(Guid.NewGuid().ToString());
            blob.UploadFromStream(reader);
            var destinoDaImagemNaNuvem = blob.Uri.ToString();
            return destinoDaImagemNaNuvem;
        }
    }
}
