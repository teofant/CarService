using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.Owners;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await _ownerService.GetAllAsync();
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
                var model = await _ownerService.GetAsync(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(OwnerCreateDTO ownerCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Owner owner = new Owner
                    {
                        FirstName = ownerCreateDTO.FirstName,
                        LastName = ownerCreateDTO.LastName,
                        Patronymic = ownerCreateDTO.Patronymic
                    };
                    var result = await _ownerService.CreateAsync(owner);
                    if (result == -1)
                        return BadRequest("Error create");
                    return Ok(owner);
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
        public async Task<IActionResult> Edit(OwnerUpdateDTO masterUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                Owner owner = new Owner
                {
                    Id = masterUpdateDTO.Id,
                    LastName = masterUpdateDTO.LastName,
                    FirstName = masterUpdateDTO.FirstName,
                    Patronymic = masterUpdateDTO.Patronymic
                };
                var result = await _ownerService.UpdateAsync(owner);
                if (result == -1)
                    return BadRequest("Error update");
                return Ok(owner);
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
                var carBrand = await _ownerService.GetAsync(id);
                if (carBrand != null)
                {
                    var result = await _ownerService.DeleteAsync(carBrand);
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
