using DemoCharacteristicsForCategory.Infrastrucutre;
using DemoCharacteristicsForCategory.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoCharacteristicsForCategory.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ISessionManager _sessionManager;

        public CategoryController(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CreateCategoryForm createCategoryForm = new CreateCategoryForm();
            createCategoryForm.Characteristics = _sessionManager.Characteristics;
            return View(createCategoryForm);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryForm form)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult AddCharacteristic(CreateCharacteristicForm form)
        {
            if (!ModelState.IsValid)
            {
                var Errors = ModelState.Keys.Select(key => new { PropertyName = key, Errors = ModelState[key].Errors.Select(e => e.ErrorMessage) });
                return BadRequest(JsonSerializer.Serialize(Errors));
            }

            _sessionManager.Add(form.Name);
            return PartialView("_Characteristics", _sessionManager.Characteristics);
        }

        public IActionResult RemoveCharacteristic(int id)
        {
            _sessionManager.Remove(id);
            return PartialView("_Characteristics", _sessionManager.Characteristics);
        }
    }
}
