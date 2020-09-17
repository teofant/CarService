using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.CarBrands;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebApp.Controllers.Catalogs
{
    public class CarBrandController : Controller
    {
        private readonly ICarBrandService _carBrandService;

        public CarBrandController(ICarBrandService carBrandService)
        {
            _carBrandService = carBrandService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _carBrandService.GetAllAsync();
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
        public async Task<IActionResult> Create(CarBrandCreateDTO carBrandCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CarBrand carBrand = new CarBrand
                    {
                        Name = carBrandCreateDTO.Name
                    };
                    var id = await _carBrandService.CreateAsync(carBrand);
                    if (id == -1)
                    {
                        ModelState.AddModelError("", "Error create");
                        return View(carBrandCreateDTO);
                    }
                    return RedirectToAction("Index");
                }
                return View(carBrandCreateDTO);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public IActionResult Edit(CarBrand carBrand)
        {
            var model = new CarBrandUpdateDTO
            {
                Id = carBrand.Id,
                Name = carBrand.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarBrandUpdateDTO carBrandUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(carBrandUpdateDTO);
                CarBrand carBrand = new CarBrand
                {
                    Id = carBrandUpdateDTO.Id,
                    Name = carBrandUpdateDTO.Name
                };
                var id = await _carBrandService.UpdateAsync(carBrand);
                if (id == -1)
                {
                    ModelState.AddModelError("", "Error update");
                    return View(carBrandUpdateDTO);
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
                var carBrand = await _carBrandService.GetAsync(id);
                if (carBrand != null)
                    await _carBrandService.DeleteAsync(carBrand);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
