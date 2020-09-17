using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.OwnerRepairs;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerRepairController : ControllerBase
    {
        private readonly IOwnerRepairService _ownerRepairService;
        public OwnerRepairController(IOwnerRepairService ownerRepairService)
        {
            _ownerRepairService = ownerRepairService;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await _ownerRepairService.GetAllAsync();
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
                var model = await _ownerRepairService.GetAsync(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(OwnerRepairCreateDTO ownerRepairCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OwnerRepair ownerRepair = new OwnerRepair
                    {
                        OwnerId = ownerRepairCreateDTO.OwnerId,
                        RepairId = ownerRepairCreateDTO.RepairId,
                    };
                    var result = await _ownerRepairService.CreateAsync(ownerRepair);
                    if (result == -1)
                        return BadRequest("Error create");
                    return Ok(ownerRepair);
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
        public async Task<IActionResult> Edit(OwnerRepairUpdateDTO ownerRepairUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                OwnerRepair ownerRepair = new OwnerRepair
                {
                    Id = ownerRepairUpdateDTO.Id,
                    RepairId = ownerRepairUpdateDTO.RepairId,
                    OwnerId = ownerRepairUpdateDTO.OwnerId
                };
                var result = await _ownerRepairService.UpdateAsync(ownerRepair);
                if (result == -1)
                    return BadRequest("Error update");
                return Ok(ownerRepair);
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
                var carBrand = await _ownerRepairService.GetAsync(id);
                if (carBrand != null)
                {
                    var result = await _ownerRepairService.DeleteAsync(carBrand);
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
