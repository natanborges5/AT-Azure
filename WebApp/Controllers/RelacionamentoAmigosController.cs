using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class RelacionamentoAmigosController : Controller
    {
        // GET: RelacionamentoAmigos
        public ActionResult Index()
        {
            return View();
        }

        // GET: RelacionamentoAmigos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RelacionamentoAmigos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RelacionamentoAmigos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: RelacionamentoAmigos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RelacionamentoAmigos/Edit/5
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

        // GET: RelacionamentoAmigos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RelacionamentoAmigos/Delete/5
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
    }
}
