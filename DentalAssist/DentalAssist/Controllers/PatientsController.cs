using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalAssist.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DentalAssist.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /<controller>/PatientsJson
        public JsonResult PatientsJson()
        {
            return Json(_unitOfWork.PatientRepository.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["PageHeader"] = "Patients";
            ViewData["PageHeaderDescription"] = "List of acticve patients";
            return View(await _unitOfWork.PatientRepository.GetPatientsAsync(searchString));
        }

        [HttpGet]
        public IActionResult PatientDetail(int id)
        {
            return View(_unitOfWork.PatientRepository.Find(p => p.PatientId == id).FirstOrDefault());
        }
    }
}
