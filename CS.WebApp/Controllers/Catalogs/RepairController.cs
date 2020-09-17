using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.Repairs;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using CS.WebApp.Models.RepairViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CS.WebApp.Controllers.Catalogs
{
    [Authorize]
    public class RepairController : Controller
    {
        private readonly IRepairService _repairService;
        private readonly IHistoryStatusService _historyStatusService;
        private readonly IRepairStatusService _repairStatusService;
        private readonly IOwnerService _ownerService;
        private readonly IMasterService _masterService;

        public RepairController(IRepairService repairService, IHistoryStatusService historyStatusService,
            IRepairStatusService repairStatusService, IOwnerService ownerService, IMasterService masterService)
        {
            _repairService = repairService;
            _historyStatusService = historyStatusService;
            _repairStatusService = repairStatusService;
            _ownerService = ownerService;
            _masterService = masterService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _repairService.GetAllAsync();
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public async Task<IActionResult> HistoryStatuses(int id)
        {
            try
            {
                var repair = await _repairService.GetAsync(id);
                var historyStatuses = await _historyStatusService.GetByRepairIdAsync(id);
                var model = new HistoryStatusViewModel(repair, historyStatuses);
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
        public async Task<IActionResult> Create(RepairCreateDTO repairCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repair repair = new Repair
                    {
                        Date = DateTime.Now,
                        MasterId = repairCreateDTO.MasterId,
                        OwnerId = repairCreateDTO.OwnerId,
                        RepairStatusId = repairCreateDTO.RepairStatusId,
                        Result = repairCreateDTO.Result,
                        Сause = repairCreateDTO.Сause
                    };
                    var result = await _repairService.CreateAsync(repair);
                    if (result == -1)
                    {
                        await GetSelected();
                        ModelState.AddModelError("", "Error create");
                        return View(repairCreateDTO);
                    }
                    return RedirectToAction("Index");
                }
                await GetSelected();
                return View(repairCreateDTO);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public async Task<IActionResult> Edit(Repair repair)
        {
            await GetSelected();
            var model = new RepairUpdateDTO
            {
                Id = repair.Id,
                MasterId = repair.MasterId,
                OwnerId = repair.OwnerId,
                RepairStatusId = repair.RepairStatusId,
                Result = repair.Result,
                Сause = repair.Сause
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RepairUpdateDTO repairUpdateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repair repair = await _repairService.GetAsync(repairUpdateDTO.Id);
                    if (repair != null)
                    {
                        HistoryStatus historyStatus = new HistoryStatus
                        {
                            Date = DateTime.Now,
                            RepairId = repair.Id,
                            RepairStatusId = repair.RepairStatusId,
                            Result = repair.Result
                        };
                        await _historyStatusService.CreateAsync(historyStatus);

                        repair.MasterId = repairUpdateDTO.MasterId;
                        repair.OwnerId = repairUpdateDTO.OwnerId;
                        repair.RepairStatusId = repairUpdateDTO.RepairStatusId;
                        repair.Result = repairUpdateDTO.Result;
                        repair.Сause = repairUpdateDTO.Сause;

                        var result = await _repairService.UpdateAsync(repair);
                        if (result == -1)
                        {
                            await GetSelected();
                            ModelState.AddModelError("", "Error update");
                            return View(repairUpdateDTO);
                        }
                        return RedirectToAction("Index");
                    }
                }
                await GetSelected();
                return View(repairUpdateDTO);
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
                var repair = await _repairService.GetAsync(id);
                if (repair != null)
                    await _repairService.DeleteAsync(repair);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        private async Task GetSelected()
        {
            ViewBag.RepairStatuses = new SelectList( await _repairStatusService.GetAllAsync(), "Id", "Name");

            var owners = await _ownerService.GetAllAsync();
            ViewBag.Owners = new SelectList(owners.Select(o =>
                new {
                    o.Id,
                    Name = $"{ o.FirstName } { o.LastName.First() }. { o.Patronymic.First() }"
                }), "Id", "Name");

            var masters = await _masterService.GetAllAsync();
            ViewBag.Masters = new SelectList(masters.Select(m =>
                new {
                    m.Id,
                    Name = $"{ m.FirstName } { m.LastName.First() }. { m.Patronymic.First() }"
                }), "Id", "Name");
        }
    }
}
