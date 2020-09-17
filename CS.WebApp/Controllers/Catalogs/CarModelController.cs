using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.CarModels;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebApp.Controllers.Catalogs
{
    [Authorize]
    public class CarModelController : Controller
    {
        private readonly ICarModelService _carModelService;

        public CarModelController(ICarModelService carModelService)
        {
            _carModelService = carModelService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _carModelService.GetAllAsync();
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
        public async Task<IActionResult> Create(CarModelCreateDTO carModelCreateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(carModelCreateDTO);
                CarModel carModel = new CarModel
                {
                    Name = carModelCreateDTO.Name
                };
                var result = await _carModelService.CreateAsync(carModel);
                if (result == -1)
                {
                    ModelState.AddModelError("", "Error create");
                    return View(carModelCreateDTO);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public IActionResult Edit(CarModel carModel)
        {
            var model = new CarModelUpdateDTO
            {
                Id = carModel.Id,
                Name = carModel.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarModelUpdateDTO carModelUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(carModelUpdateDTO);
                CarModel carModel = new CarModel
                {
                    Id = carModelUpdateDTO.Id,
                    Name = carModelUpdateDTO.Name
                };
                var result = await _carModelService.UpdateAsync(carModel);
                if (result == -1)
                {
                    ModelState.AddModelError("", "Error update");
                    return View(carModelUpdateDTO);
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
                var carModel = await _carModelService.GetAsync(id);
                if (carModel != null)
                    await _carModelService.DeleteAsync(carModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
