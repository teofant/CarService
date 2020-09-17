using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.Cars;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await _carService.GetAllAsync();
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
                var model = await _carService.GetAsync(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
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
                        return BadRequest("Error create");
                    return Ok(car);
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
        public async Task<IActionResult> Edit(CarUpdateDTO carUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
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
                    return BadRequest("Error update");
                return Ok(car);
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
                var carBrand = await _carService.GetAsync(id);
                if (carBrand != null)
                {
                    var result = await _carService.DeleteAsync(carBrand);
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
