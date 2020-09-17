using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Core.DTO.Repairs;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        private readonly IRepairService _repairService;
        private readonly IHistoryStatusService _historyStatusService;

        public RepairController(IRepairService repairService, IHistoryStatusService historyStatusService)
        {
            _repairService = repairService;
            _historyStatusService = historyStatusService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await _repairService.GetAllAsync();
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
                var model = await _repairService.GetAsync(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(RepairCreateDTO repairCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repair repair = new Repair
                    {
                        Date = DateTime.Now,
                        MasterId = repairCreateDTO.MasterId,
                        OwnerId = repairCreateDTO.OwnerId,
                        RepairStatusId = repairCreateDTO.RepairStatusId,
                        Result = repairCreateDTO.Result,
                        Сause = repairCreateDTO.Сause
                    };
                    var result = await _repairService.CreateAsync(repair);
                    if (result == -1)
                        return BadRequest("Error create");
                    return Ok(repair);
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
        public async Task<IActionResult> Edit(RepairUpdateDTO repairUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                Repair repair = await _repairService.GetAsync(repairUpdateDTO.Id);
                if (repair != null)
                {
                    HistoryStatus historyStatus = new HistoryStatus
                    {
                        Date = DateTime.Now,
                        RepairId = repair.Id,
                        RepairStatusId = repair.RepairStatusId,
                        Result = repair.Result
                    };
                    await _historyStatusService.CreateAsync(historyStatus);

                    repair.MasterId = repairUpdateDTO.MasterId;
                    repair.OwnerId = repairUpdateDTO.OwnerId;
                    repair.RepairStatusId = repairUpdateDTO.RepairStatusId;
                    repair.Result = repairUpdateDTO.Result;
                    repair.Сause = repairUpdateDTO.Сause;

                    var result = await _repairService.UpdateAsync(repair);
                    if (result == -1)
                        return BadRequest("Error update");
                    return Ok(repair);
                }
                return BadRequest("Error update");
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
                var carBrand = await _repairService.GetAsync(id);
                if (carBrand != null)
                {
                    var result = await _repairService.DeleteAsync(carBrand);
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
