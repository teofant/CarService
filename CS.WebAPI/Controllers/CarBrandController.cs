using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.CarBrands;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandController : ControllerBase
    {
        private readonly ICarBrandService _carBrandService;
        public CarBrandController(ICarBrandService carBrandService)
        {
            _carBrandService = carBrandService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await _carBrandService.GetAllAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var model = await _carBrandService.GetAsync(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
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
                    var result = await _carBrandService.CreateAsync(carBrand);
                    if (result == -1)
                        return BadRequest("Error create");
                    return Ok(carBrand);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Edit(CarBrandUpdateDTO carBrandUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                CarBrand carBrand = new CarBrand
                {
                    Id = carBrandUpdateDTO.Id,
                    Name = carBrandUpdateDTO.Name
                };
                var result = await _carBrandService.UpdateAsync(carBrand);
                if (result == -1)
                    return BadRequest("Error update");
                return Ok(carBrand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var carBrand = await _carBrandService.GetAsync(id);
                if (carBrand != null)
                {
                    var result = await _carBrandService.DeleteAsync(carBrand);
                    if (result == -1)
                        return BadRequest("Error delete");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
