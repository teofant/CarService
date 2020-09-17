using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.RepairStatuses;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairStatusController : ControllerBase
    {
        private readonly IRepairStatusService _repairStatusService;

        public RepairStatusController(IRepairStatusService repairStatusService)
        {
            _repairStatusService = repairStatusService;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await _repairStatusService.GetAllAsync();
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
                var model = await _repairStatusService.GetAsync(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(RepairStatusCreateDTO repairStatusCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RepairStatus repairStatus = new RepairStatus
                    {
                        Name = repairStatusCreateDTO.Name
                    };
                    var result = await _repairStatusService.CreateAsync(repairStatus);
                    if (result == -1)
                        return BadRequest("Error create");
                    return Ok(repairStatus);
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
        public async Task<IActionResult> Edit(RepairStatusUpdateDTO repairStatusUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                RepairStatus repairStatus = new RepairStatus
                {
                    Id = repairStatusUpdateDTO.Id,
                    Name = repairStatusUpdateDTO.Name
                };
                var result = await _repairStatusService.UpdateAsync(repairStatus);
                if (result == -1)
                    return BadRequest("Error update");
                return Ok(repairStatus);
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
                var carBrand = await _repairStatusService.GetAsync(id);
                if (carBrand != null)
                {
                    var result = await _repairStatusService.DeleteAsync(carBrand);
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
