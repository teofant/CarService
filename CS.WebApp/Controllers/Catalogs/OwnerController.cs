using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.Owners;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebApp.Controllers.Catalogs
{
    [Authorize]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _ownerService.GetAllAsync();
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
        public async Task<IActionResult> Create(OwnerCreateDTO ownerCreateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(ownerCreateDTO);
                Owner owner = new Owner
                {
                    FirstName = ownerCreateDTO.FirstName,
                    LastName = ownerCreateDTO.LastName,
                    Patronymic = ownerCreateDTO.Patronymic
                };
                var result = await _ownerService.CreateAsync(owner);
                if (result == -1)
                {
                    ModelState.AddModelError("", "Error create");
                    return View(ownerCreateDTO);
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
            var model = new OwnerUpdateDTO
            {
                Id = master.Id,
                LastName = master.LastName,
                FirstName = master.FirstName,
                Patronymic = master.Patronymic
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OwnerUpdateDTO ownerUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(ownerUpdateDTO);
                Owner owner = new Owner
                {
                    Id = ownerUpdateDTO.Id,
                    LastName = ownerUpdateDTO.LastName,
                    FirstName = ownerUpdateDTO.FirstName,
                    Patronymic = ownerUpdateDTO.Patronymic
                };
                var result = await _ownerService.UpdateAsync(owner);
                if (result == -1)
                {
                    ModelState.AddModelError("", "Error update");
                    return View(ownerUpdateDTO);
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
                var owner = await _ownerService.GetAsync(id);
                if (owner != null)
                    await _ownerService.DeleteAsync(owner);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
