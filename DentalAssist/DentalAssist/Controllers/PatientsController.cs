﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalAssist.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using DentalAssist.Models;
using Microsoft.AspNetCore.Routing;
using DentalAssist.ViewModels;
using System;
using NToastNotify;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DentalAssist.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<PatientsController> _localizer;
        private IToastNotification _toastNotification;

        public PatientsController(IUnitOfWork unitOfWork, IStringLocalizer<PatientsController> localizer, IToastNotification toastNotification)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
            _toastNotification = toastNotification;
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
        public async Task<IActionResult> PatientDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _unitOfWork.PatientRepository.GetPatientAsync((int)id);

            if(patient == null)
            {
                return NotFound();
            }

            //var patientDetailViewModel = new PatientDetailViewModel(_unitOfWork) { Patient = patient };

            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> EditPatient(Patient patient)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.PatientRepository.UpdatePatient(patient);
                try
                {
                    await _unitOfWork.SaveChangesAsync();
                    _toastNotification.AddToastMessage("Task Completed", "Patient details were saved succesfully", ToastEnums.ToastType.Success);
                }
                catch (Exception e)
                {
                    _toastNotification.AddToastMessage("Task Failed", e.Message, ToastEnums.ToastType.Error);
                }
            }

            return RedirectToAction("PatientDetail", new RouteValueDictionary(new { controller = "Patients", action = "PatientDetail", id = patient.PatientId }));
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromForm]Patient newPatient)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PatientRepository.Add(newPatient);
                try
                {
                    await _unitOfWork.SaveChangesAsync();
                    _toastNotification.AddToastMessage("Task Completed", "Patient was added succesfully", ToastEnums.ToastType.Success);
                }
                catch (Exception e)
                {
                    _toastNotification.AddToastMessage("Task Failed", e.Message, ToastEnums.ToastType.Error);
                }
            }

            return RedirectToAction("PatientDetail", new RouteValueDictionary(new { controller = "Patients", action = "PatientDetail", id = newPatient.PatientId }));
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEditPatientDentalOperation(int? id, int patientId)
        {
            if (id == null)
            {
                var newDentalOperation = new DentalOperation
                {
                    PatientId = patientId,
                    DentistId = 1,
                    StarDate = DateTime.UtcNow
                };

                var dopVM = new EditDentalOperationViewModel(_unitOfWork) { DentalOperation = newDentalOperation };

                var patient = await _unitOfWork.PatientRepository.GetPatientAsync(patientId);
                ViewData["PageHeader"] = patient.FullName;
                ViewData["FormTitle"] = _localizer["Add dental operation"];
                return View(dopVM);
            }

            var dentalOperation = await _unitOfWork.PatientRepository.GetDentalOperationAsync((int)id);
            ViewData["PageHeader"] = dentalOperation.Patient.FullName;
            ViewData["FormTitle"] = _localizer["Edit dental operation"];
            return View(new EditDentalOperationViewModel(_unitOfWork) { DentalOperation = dentalOperation });
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEditPatientDentalOperation(DentalOperation DentalOperation)
        {
            var msg = "";

            if (ModelState.IsValid)
            {
                if (DentalOperation.DentalOperationId < 1)
                {
                    _unitOfWork.PatientRepository.AddDentalOperation(DentalOperation);
                    msg = "Dental operation was added successfully";
                }
                else
                {
                    _unitOfWork.PatientRepository.UpdateDentalOperation(DentalOperation);
                    msg = "Dental operation was saved successfully";
                }
                try
                {
                    await _unitOfWork.SaveChangesAsync();
                    _toastNotification.AddToastMessage("Task Completed", msg, ToastEnums.ToastType.Success);
                    return RedirectToAction("PatientDetail", new RouteValueDictionary(new { controller = "Patients", action = "PatientDetail", id = DentalOperation.PatientId }));
                }
                catch (Exception e)
                {
                    _toastNotification.AddToastMessage("Task Failed", e.Message, ToastEnums.ToastType.Error);
                }
            }
            else
            {
                _toastNotification.AddToastMessage("Task Failed", "Data is not valid", ToastEnums.ToastType.Error);                
            }

            return RedirectToAction("PatientDetail", new RouteValueDictionary(new { controller = "Patients", action = "PatientDetail", id = DentalOperation.PatientId }));

        }
    }
}
