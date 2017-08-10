using DentalAssist.Services;
using DentalAssist.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalAssist.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<PatientsController> _localizer;

        public DashboardController(IUnitOfWork unitOfWork, IStringLocalizer<PatientsController> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dashVM = new DashboardViewModel
            {
                GroupedDentalOperations = await _unitOfWork.DashboardRepository.GetGroupedDentalOperationsAsync()
            };

            return View(dashVM);
        }
    }
}
