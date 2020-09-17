using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.RepairStatuses;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebApp.Controllers.Catalogs
{
    public class RepairStatusController : Controller
    {
        private readonly IRepairStatusService _repairStatusService;

        public RepairStatusController(IRepairStatusService repairStatusService)
        {
            _repairStatusService = repairStatusService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _repairStatusService.GetAllAsync();
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RepairStatusCreateDTO repairStatusCreateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(repairStatusCreateDTO);
                RepairStatus repairStatus = new RepairStatus
                {
                    Name = repairStatusCreateDTO.Name
                };
                var id = await _repairStatusService.CreateAsync(repairStatus);
                if (id == -1)
                {
                    ModelState.AddModelError("", "Error create");
                    return View(repairStatusCreateDTO);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public IActionResult Edit(RepairStatus repairStatus)
        {
            var model = new RepairStatusUpdateDTO
            {
                Id = repairStatus.Id,
                Name = repairStatus.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RepairStatusUpdateDTO repairStatusUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(repairStatusUpdateDTO);
                RepairStatus repairStatus = new RepairStatus
                {
                    Id = repairStatusUpdateDTO.Id,
                    Name = repairStatusUpdateDTO.Name
                };
                var id = await _repairStatusService.UpdateAsync(repairStatus);
                if (id == -1)
                {
                    ModelState.AddModelError("", "Error update");
                    return View(repairStatusUpdateDTO);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var repairStatus = await _repairStatusService.GetAsync(id);
                if (repairStatus != null)
                    await _repairStatusService.DeleteAsync(repairStatus);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
