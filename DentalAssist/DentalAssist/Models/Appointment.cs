using System;

namespace DentalAssist.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime StartTime { get; set; }

        public string Description { get; set; }

        public int PatientId { get; set; }

        public int DentistId { get; set; }

        public Patient Patient { get; set; }

        public Dentist Dentist { get; set; }
    }
}
