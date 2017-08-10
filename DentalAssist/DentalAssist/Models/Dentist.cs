using System.Collections.Generic;

namespace DentalAssist.Models
{
    public class Dentist
    {
        public int DentistId { get; set; }

        public ICollection<DentalOperation> DentalOperations { get; set; } = new List<DentalOperation>();

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
