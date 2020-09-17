using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.CarOwner;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CS.WebApp.Controllers.Catalogs
{
    public class CarOwnerController : Controller
    {
        private readonly ICarOwnerService _carOwnerService;
        private readonly ICarService _carService;
        private readonly IOwnerService _ownerService;

        public CarOwnerController(ICarOwnerService carOwnerService, ICarService carService,
            IOwnerService ownerService)
        {
            _carOwnerService = carOwnerService;
            _carService = carService;
            _ownerService = ownerService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _carOwnerService.GetAllAsync();
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
        public async Task<IActionResult> Create(CarOwnerCreateDTO carOwnerCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CarOwner carOwner = new CarOwner
                    {
                        CarId = carOwnerCreateDTO.CarId,
                        OwnerId = carOwnerCreateDTO.OwnerId,
                    };
                    var id = await _carOwnerService.CreateAsync(carOwner);
                    if (id == -1)
                    {
                        await GetSelected();
                        ModelState.AddModelError("", "Error create");
                        return View(carOwnerCreateDTO);
                    }
                    return RedirectToAction("Index");
                }
                await GetSelected();
                return View(carOwnerCreateDTO);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public async Task<IActionResult> Edit(CarOwner carOwner)
        {
            await GetSelected();
            var model = new CarOwnerUpdateDTO
            {
                Id = carOwner.Id,
                CarId = carOwner.CarId,
                OwnerId = carOwner.OwnerId
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarOwnerUpdateDTO carOwnerUpdateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CarOwner carOwner = new CarOwner
                    {
                        Id = carOwnerUpdateDTO.Id,
                        CarId = carOwnerUpdateDTO.CarId,
                        OwnerId = carOwnerUpdateDTO.OwnerId
                    };
                    var id = await _carOwnerService.UpdateAsync(carOwner);
                    if (id == -1)
                    {
                        await GetSelected();
                        ModelState.AddModelError("", "Error update");
                        return View(carOwnerUpdateDTO);
                    }
                    return RedirectToAction("Index");
                }
                await GetSelected();
                return View(carOwnerUpdateDTO);
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
                var carOwner = await _carOwnerService.GetAsync(id);
                if (carOwner != null)
                    await _carOwnerService.DeleteAsync(carOwner);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        private async Task GetSelected()
        {
            var cars = await _carService.GetAllAsync();
            ViewBag.Cars = new SelectList(cars.Select(o =>
                new {
                    o.Id,
                    Name = $"Mileage: { o.Mileage } DateIssue: { o.DateIssue.ToShortDateString() } { o.CarBrand.Name } { o.CarModel.Name }"
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
