using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.Masters;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebApp.Controllers.Catalogs
{
    public class MasterController : Controller
    {
        private readonly IMasterService _masterService;

        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _masterService.GetAllAsync();
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
        public async Task<IActionResult> Create(MasterCreateDTO masterCreateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(masterCreateDTO);
                Master master = new Master
                {
                    FirstName = masterCreateDTO.FirstName,
                    LastName = masterCreateDTO.LastName,
                    Patronymic = masterCreateDTO.Patronymic
                };
                var id = await _masterService.CreateAsync(master);
                if (id == -1)
                {
                    ModelState.AddModelError("", "Error create");
                    return View(masterCreateDTO);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public IActionResult Edit(Master master)
        {
            var model = new MasterUpdateDTO
            {
                Id = master.Id,
                LastName = master.LastName,
                FirstName = master.FirstName,
                Patronymic = master.Patronymic
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MasterUpdateDTO masterUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(masterUpdateDTO);
                Master master = new Master
                {
                    Id = masterUpdateDTO.Id,
                    LastName = masterUpdateDTO.LastName,
                    FirstName = masterUpdateDTO.FirstName,
                    Patronymic = masterUpdateDTO.Patronymic
                };
                var id = await _masterService.UpdateAsync(master);
                if (id == -1)
                {
                    ModelState.AddModelError("", "Error update");
                    return View(masterUpdateDTO);
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
                var master = await _masterService.GetAsync(id);
                if (master != null)
                    await _masterService.DeleteAsync(master);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
