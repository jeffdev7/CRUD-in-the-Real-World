using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.domain.Enums;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using smartfy.portal_api.presentation.UI.Web.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartfy.portal_api.presentation.UI.Web.Controllers
{
    public class VeiculoController : BaseController
    {
        

        public VeiculoController(ApplicationDbContext db) : base(db)
        {
        }

        public IActionResult Index()
        {
            return View(Db.Veiculos);
        }
      

        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        { 
            return Json(await Db.Veiculos
                .Include(c=>c.TipoVeiculo)
               .Select(r => new
                  {
                      DT_RowId = r.Id,
                      tipoveiculo = r.TipoVeiculo.Modelo,
                      placa = r.Placa,
                      parking = r.Parking,
                      status = r.Status,
                  }).ToDataSourceAsync(request));
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Veiculo vm)
        {
            LoadViewBags();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Db.Veiculos.Add(vm);
            Db.SaveChanges();

            
            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
           
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            LoadViewBags();

            var item = Db.Veiculos.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Veiculo vm)
        {
            LoadViewBags();
            if (!ModelState.IsValid)
            {
                LoadViewBags();
                return View(vm);
            }

            var item = Db.Veiculos.AsNoTracking().Where(c => c.Id == vm.Id);
            if (item == null) return BadRequest();

            Db.Entry(vm).State = EntityState.Modified;
            Db.SaveChanges();

            NotifySuccess("Sucesso", "Cadastro atualizado com sucesso!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            LoadViewBags();
            var item = Db.Veiculos.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Veiculo Veiculo)
        {
            LoadViewBags();
            var item = Db.Veiculos.FirstOrDefault(c => c.Id == Veiculo.Id);

            if (item == null) return BadRequest();

            Db.Veiculos.Remove(item);
            Db.SaveChanges();

            NotifySuccess("Sucesso", "Cadastro removido com sucesso.");

            return RedirectToAction("Index");
        }

        private void LoadViewBags()
        {
            ViewBag.Status = new List<SelectListItem>()
            {
                new SelectListItem("Ocupado", Convert.ToString((int)EStatus.Ocupado)),
                new SelectListItem("Livre", Convert.ToString((int)EStatus.Livre)),
            };

            ViewBag.TipoVeiculos = Db.TipoVeiculos.Select(c => new SelectListItem($"{c.Modelo}", c.Id.ToString()));
        }
    }
}
