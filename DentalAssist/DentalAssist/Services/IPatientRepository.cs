using DentalAssist.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DentalAssist.Services
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetPatientsAsync(string searchString);

        Task<Patient> GetPatientAsync(int id);

        void UpdatePatient(Patient patient);

        void UpdateDentalOperation(DentalOperation dop);

        Task<List<DentalOperationItem>> GetDentalOperationItemsAsync();

        void AddDentalOperation(DentalOperation dop);

        Task<DentalOperation> GetDentalOperationAsync(int id);
    }
}
