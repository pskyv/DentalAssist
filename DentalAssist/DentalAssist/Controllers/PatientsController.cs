using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalAssist.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DentalAssist.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<PatientsController> _localizer;

        public PatientsController(IUnitOfWork unitOfWork, IStringLocalizer<PatientsController> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        // GET: /<controller>/PatientsJson
        public JsonResult PatientsJson()
        {
            return Json(_unitOfWork.PatientRepository.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["PageHeader"] = _localizer["Patients"];
            ViewData["PageHeaderDescription"] = _localizer["List of acticve patients"];
            return View(await _unitOfWork.PatientRepository.GetPatientsAsync(searchString));
        }

        [HttpGet]
        public async Task<IActionResult> PatientDetail(int id)
        {
            //if(id == null)
            //{
            //    return NotFound();
            //}

            var patient = await _unitOfWork.PatientRepository.GetPatientAsync(id);

            if(patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }
    }
}
