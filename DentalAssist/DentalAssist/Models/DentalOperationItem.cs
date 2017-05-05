
using System.Collections.Generic;

namespace DentalAssist.Models
{
    public class DentalOperationItem
    {
        public int DentalOperationItemId { get; set; }

        public string Description { get; set; }

        public ICollection<DentalOperation> DentalOperations { get; set; } = new List<DentalOperation>();
    }
}
