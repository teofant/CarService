using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.OwnerRepairs;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CS.WebApp.Controllers.Catalogs
{
    [Authorize]
    public class OwnerRepairController : Controller
    {
        private readonly IOwnerRepairService _ownerRepairService;
        private readonly IOwnerService _ownerService;
        private readonly IRepairService _repairService;

        public OwnerRepairController(IOwnerRepairService ownerRepairService, IOwnerService ownerService,
            IRepairService repairService)
        {
            _ownerRepairService = ownerRepairService;
            _ownerService = ownerService;
            _repairService = repairService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _ownerRepairService.GetAllAsync();
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public async Task<IActionResult> Create()
        {
            await GetSelected();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OwnerRepairCreateDTO ownerRepairCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OwnerRepair ownerRepair = new OwnerRepair
                    {
                        OwnerId = ownerRepairCreateDTO.OwnerId,
                        RepairId = ownerRepairCreateDTO.RepairId,
                    };
                    var result = await _ownerRepairService.CreateAsync(ownerRepair);
                    if (result == -1)
                    {
                        await GetSelected();
                        ModelState.AddModelError("", "Error create");
                        return View(ownerRepairCreateDTO);
                    }
                    return RedirectToAction("Index");
                }
                await GetSelected();
                return View(ownerRepairCreateDTO);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public async Task<IActionResult> Edit(OwnerRepair ownerRepair)
        {
            await GetSelected();
            var model = new OwnerRepairUpdateDTO
            {
                Id = ownerRepair.Id,
                RepairId = ownerRepair.RepairId,
                OwnerId = ownerRepair.OwnerId
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OwnerRepairUpdateDTO ownerRepairUpdateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OwnerRepair ownerRepair = new OwnerRepair
                    {
                        Id = ownerRepairUpdateDTO.Id,
                        RepairId = ownerRepairUpdateDTO.RepairId,
                        OwnerId = ownerRepairUpdateDTO.OwnerId
                    };
                    var result = await _ownerRepairService.UpdateAsync(ownerRepair);
                    if (result == -1)
                    {
                        await GetSelected();
                        ModelState.AddModelError("", "Error update");
                        return View(ownerRepairUpdateDTO);
                    }
                    return RedirectToAction("Index");
                }
                await GetSelected();
                return View(ownerRepairUpdateDTO);
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
                var ownerRepair = await _ownerRepairService.GetAsync(id);
                if (ownerRepair != null)
                    await _ownerRepairService.DeleteAsync(ownerRepair);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        private async Task GetSelected()
        {
            var repairs = await _repairService.GetAllAsync();
            ViewBag.Repairs = new SelectList(repairs.Select(r =>
                new {
                    r.Id,
                    Name = $"Date: { r.Date.ToShortDateString() } Result: { r.Result } Сause: { r.Сause } FirstNameMaster: { r.Master.FirstName }"
                }), "Id", "Name");

            var owners = await _ownerService.GetAllAsync();
            ViewBag.Owners = new SelectList(owners.Select(o =>
                new {
                    o.Id,
                    Name = $"{ o.FirstName } { o.LastName } { o.Patronymic }"
                }), "Id", "Name");
        }
    }
}
