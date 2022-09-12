using Core.Entity;
using Core.Model;
using Core.Rest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class WasteController : Controller
    {
        private readonly IRestService _restService;
        public WasteController(IRestService restService)
        {
            _restService = restService;
        }
        public IActionResult List()
        {
            return View();
        }
        public async Task<IActionResult> ListResult()
        {
            var data = await _restService.Get<List<Waste>>($"waste/getall");
            return Json(data);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _restService.Post<int>($"waste/delete", new WasteDeleteDto { Id = id });
            return Json(data);
        }
        public async Task<IActionResult> Get(int id)
        {
            var result = new WasteUpdateDto();

            if (id > 0)
            {
                var getData = await _restService.Get<WasteUpdateDto>($"waste/getbyid/{id}");

                if (getData.Status)
                    result = getData.Data;
            }

            var dropdowns = await _restService.Get<WastePageDropdown>($"waste/getalldropdowns");

            ViewBag.DropdownList = dropdowns;

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(WasteUpdateDto data)
        {
            var result = await _restService.Post<int>($"waste/addoredit", data);
            return Json(result);
        }
    }
}
