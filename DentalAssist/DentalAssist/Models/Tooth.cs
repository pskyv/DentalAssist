using System.Collections.Generic;

namespace DentalAssist.Models
{
    public class Tooth
    {
        public int ToothId { get; set; }

        public string Description { get; set; }

        public int Index { get; set; }

        public ICollection<DentalOperationTooth> DentalOperationTeeth { get; set; } = new List<DentalOperationTooth>();
    }
}
