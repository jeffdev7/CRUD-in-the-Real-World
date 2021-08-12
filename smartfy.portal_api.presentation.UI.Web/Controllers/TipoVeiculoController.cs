using Microsoft.AspNetCore.Mvc;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using smartfy.portal_api.presentation.UI.Web.DataTables;
using smartfy.portal_api.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace smartfy.portal_api.presentation.UI.Web.Controllers
{
    public class TipoVeiculoController : BaseController
    {
        public TipoVeiculoController(ApplicationDbContext db) : base(db) { }

        [HttpGet]
        public IActionResult Index()
        {
            return View(Db.TipoVeiculos);
        }

        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        {
            return Json(await Db.TipoVeiculos
                .Select(r => new
                {
                    DT_RowId = r.Id,
                    modelo = r.Modelo,
                    descricao = r.Descricao
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
        public IActionResult Create(TipoVeiculo vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Db.TipoVeiculos.Add(vm);
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso: ", "Departamento cadastrado com sucesso!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var item = Db.TipoVeiculos.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            LoadViewBags();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TipoVeiculo vm)
        {
            if (!ModelState.IsValid)
            {
                LoadViewBags();
                return View(vm);
            }

            var item = Db.TipoVeiculos.AsNoTracking().Where(c => c.Id == vm.Id);
            if (item == null) return BadRequest();

            Db.Entry(vm).State = EntityState.Modified;
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso", "Dados do departamento atualizados com sucesso!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var item = Db.TipoVeiculos.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(TipoVeiculo TipoVeiculo)
        {
            var item = Db.TipoVeiculos.FirstOrDefault(c => c.Id == TipoVeiculo.Id);

            if (item == null) return BadRequest();

            Db.TipoVeiculos.Remove(item);
            Db.SaveChanges();
            NotifySuccess("Sucesso", "Departamento removido com sucesso.");

            return RedirectToAction("Index");
        }

        private void LoadViewBags()
        {
            ViewBag.TipoVeiculoId = Db.TipoVeiculos.ToList();
           
        }
    }
}

