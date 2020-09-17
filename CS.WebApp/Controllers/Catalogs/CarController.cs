using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.Cars;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CS.WebApp.Controllers.Catalogs
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarBrandService _carBrandService;
        private readonly ICarModelService _carModelService;
        private readonly IOwnerService _ownerService;

        public CarController(ICarService carService, ICarBrandService carBrandService,
            ICarModelService carModelService, IOwnerService ownerService)
        {
            _carService = carService;
            _carBrandService = carBrandService;
            _carModelService = carModelService;
            _ownerService = ownerService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _carService.GetAllAsync();
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
        public async Task<IActionResult> Create(CarCreateDTO carCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Car car = new Car
                    {
                        OwnerId = carCreateDTO.OwnerId,
                        CarBrandId = carCreateDTO.CarBrandId,
                        CarModelId = carCreateDTO.CarModelId,
                        DateIssue = carCreateDTO.DateIssue,
                        Mileage = carCreateDTO.Mileage
                    };
                    var result = await _carService.CreateAsync(car);
                    if (result == -1)
                    {
                        await GetSelected();
                        ModelState.AddModelError("", "Error create");
                        return View(carCreateDTO);
                    }
                    return RedirectToAction("Index");
                }
                await GetSelected();
                return View(carCreateDTO);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public async Task<IActionResult> Edit(Car car)
        {
            await GetSelected();
            var model = new CarUpdateDTO
            {
                Id = car.Id,
                OwnerId = car.OwnerId,
                DateIssue = car.DateIssue,
                CarBrandId = car.CarBrandId,
                CarModelId = car.CarModelId,
                Mileage = car.Mileage
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarUpdateDTO carUpdateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Car car = new Car
                    {
                        Id = carUpdateDTO.Id,
                        OwnerId = carUpdateDTO.OwnerId,
                        CarBrandId = carUpdateDTO.CarBrandId,
                        CarModelId = carUpdateDTO.CarModelId,
                        DateIssue = carUpdateDTO.DateIssue,
                        Mileage = carUpdateDTO.Mileage
                    };
                    var result = await _carService.UpdateAsync(car);
                    if (result == -1)
                    {
                        await GetSelected();
                        ModelState.AddModelError("", "Error update");
                        return View(carUpdateDTO);
                    }
                    return RedirectToAction("Index");
                }
                await GetSelected();
                return View(carUpdateDTO);
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
                var car = await _carService.GetAsync(id);
                if (car != null)
                    await _carService.DeleteAsync(car);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        private async Task GetSelected()
        {
            ViewBag.CarBrands = new SelectList(await _carBrandService.GetAllAsync(), "Id", "Name");
            ViewBag.CarModels = new SelectList(await _carModelService.GetAllAsync(), "Id", "Name");

            var owners = await _ownerService.GetAllAsync();
            ViewBag.Owners = new SelectList(owners.Select(o =>
                new {   o.Id,
                        Name = $"{ o.FirstName } { o.LastName } { o.Patronymic }"
                    }), "Id", "Name");
        }
    }
}
