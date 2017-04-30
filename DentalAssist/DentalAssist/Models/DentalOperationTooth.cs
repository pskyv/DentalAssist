
namespace DentalAssist.Models
{
    public class DentalOperationTooth
    {
        public int DentalOperationId { get; set; }

        public int ToothId { get; set; }

        public DentalOperation DentalOperation { get; set; }

        public Tooth Tooth { get; set; }

    }
}
