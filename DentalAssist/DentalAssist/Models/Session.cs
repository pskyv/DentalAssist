using System;

namespace DentalAssist.Models
{
    public class Session
    {
        public int SessionId { get; set; }

        public DateTime SessionDate { get; set; }

        public int DentalOperationId { get; set; }

        public string Notes { get; set; }

        public DentalOperation DentalOperation { get; set; }
    }
}
