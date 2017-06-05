using DentalAssist.Models;
using DentalAssist.Services;
using System;
using System.Collections.Generic;

namespace DentalAssist.ViewModels
{
    public class EditDentalOperationViewModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditDentalOperationViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Initialization();
        }

        public DentalOperation DentalOperation { get; set; }

        public List<DentalOperationItem> DentalOperationItems { get; set; }

        private async void Initialization()
        {
            DentalOperationItems = await _unitOfWork.PatientRepository.GetDentalOperationItemsAsync();
        }
    }
}
