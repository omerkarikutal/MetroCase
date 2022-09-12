using Business.Abstract;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WasteController : ControllerBase
    {
        private readonly IWasteService _wasteService;
        private readonly IComponentService _componentService;
        public WasteController(IWasteService wasteService, IComponentService componentService)
        {
            _wasteService = wasteService;
            _componentService = componentService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _wasteService.GetAll());
        }
        [HttpPost("addoredit")]
        public async Task<IActionResult> Add(WasteUpdateDto update)
        {
            return Ok(await _wasteService.AddOrEdit(update));
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _wasteService.GetById(id));
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(WasteDeleteDto wasteAddDto)
        {
            return Ok(await _wasteService.Delete(wasteAddDto));
        }
        [HttpGet("getalldropdowns")]
        public async Task<IActionResult> GetAllDropdowns()
        {
            return Ok(await _componentService.GetAllDropdown());
        }

    }
}
