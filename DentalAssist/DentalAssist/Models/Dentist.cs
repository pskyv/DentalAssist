using System.Collections.Generic;

namespace DentalAssist.Models
{
    public class Dentist
    {
        public int DentistId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        public string Phone { get; set; }

        public string Email { get; set; }

        public ICollection<DentalOperation> DentalOperations { get; set; } = new List<DentalOperation>();

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
