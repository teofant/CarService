using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.CarOwner;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarOwnerController : ControllerBase
    {
        private readonly ICarOwnerService _carOwnerService;

        public CarOwnerController(ICarOwnerService carOwnerService)
        {
            _carOwnerService = carOwnerService;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await _carOwnerService.GetAllAsync();
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
                var model = await _carOwnerService.GetAsync(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
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
                    var result = await _carOwnerService.CreateAsync(carOwner);
                    if (result == -1)
                        return BadRequest("Error create");
                    return Ok(carOwner);
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
        public async Task<IActionResult> Edit(CarOwnerUpdateDTO carOwnerUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                CarOwner carOwner = new CarOwner
                {
                    Id = carOwnerUpdateDTO.Id,
                    CarId = carOwnerUpdateDTO.CarId,
                    OwnerId = carOwnerUpdateDTO.OwnerId
                };
                var result = await _carOwnerService.UpdateAsync(carOwner);
                if (result == -1)
                    return BadRequest("Error update");
                return Ok(carOwner);
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
                var carBrand = await _carOwnerService.GetAsync(id);
                if (carBrand != null)
                {
                    var result = await _carOwnerService.DeleteAsync(carBrand);
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
