using System;
using System.Collections.Generic;

namespace DentalAssist.Models
{
    public class DentalOperation
    {
        public int DentalOperationId { get; set; }

        public int PatientId { get; set; }

        public int DentistId { get; set; }

        public int DentalOperationItemId { get; set; }

        public DentalOperationStatus Status { get; set; }

        public DateTime StarDate { get; set; }

        public decimal Price { get; set; }

        public string Notes { get; set; }        

        public Patient Patient { get; set; }

        public Dentist Dentist { get; set; }

        public DentalOperationItem DentalOperationItem { get; set; }

        public ICollection<DentalOperationTooth> DentalOperationTeeth { get; set; } = new List<DentalOperationTooth>();

        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
