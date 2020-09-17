using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.Masters;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;

        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await _masterService.GetAllAsync();
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
                var model = await _masterService.GetAsync(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(MasterCreateDTO masterCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Master master = new Master
                    {
                        FirstName = masterCreateDTO.FirstName,
                        LastName = masterCreateDTO.LastName,
                        Patronymic = masterCreateDTO.Patronymic
                    };
                    var result = await _masterService.CreateAsync(master);
                    if (result == -1)
                        return BadRequest("Error create");
                    return Ok(master);
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
        public async Task<IActionResult> Edit(MasterUpdateDTO masterUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                Master master = new Master
                {
                    Id = masterUpdateDTO.Id,
                    LastName = masterUpdateDTO.LastName,
                    FirstName = masterUpdateDTO.FirstName,
                    Patronymic = masterUpdateDTO.Patronymic
                };
                var result = await _masterService.UpdateAsync(master);
                if (result == -1)
                    return BadRequest("Error update");
                return Ok(master);
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
                var carBrand = await _masterService.GetAsync(id);
                if (carBrand != null)
                {
                    var result = await _masterService.DeleteAsync(carBrand);
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
