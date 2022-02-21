using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastRecrut.Web.Services;
using FastRecrut.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FastRecrut.Web.Controllers
{
    public class ParticipantDataController : Controller
    {
        private readonly ParticipantDataService pdataService = new ParticipantDataService();

        // GetAll: /api/Quiz
        public async Task<IActionResult> Index()
        {
            var pdataList = await pdataService.GetAll();
            return View(pdataList);
        }

        // Create: /api/Create
        public IActionResult Create()
        {
            var pdataVM = new ParticipantDataViewModel();
            return View(pdataVM);
        }

        // Create : /api/Create
        [HttpPost]
        public async Task<IActionResult> Create(ParticipantDataViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await pdataService.Create(vm);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // Update : /api/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();
            var pdata = await pdataService.Get((int)id);
            if (pdata == null) return NotFound();

            return View(pdata);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ParticipantDataViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await pdataService.Update(vm.participantData.Id, vm);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // /Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var pdata = await pdataService.Delete((int)id);
            if (pdata == false) return NotFound();
            TempData["SuccessMessage"] = "Deleted Successfully"; // Todo : Used with Alertify (otpion)
            return RedirectToAction("Index");
        }
    }
}
