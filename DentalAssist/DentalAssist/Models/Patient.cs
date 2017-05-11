using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentalAssist.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => LastName + " " + FirstName;

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? BirthDate { get; set; }

        public string SSN { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        public ICollection<DentalOperation> DentalOperations { get; set; } = new List<DentalOperation>();

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
