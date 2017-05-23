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
    }
}
