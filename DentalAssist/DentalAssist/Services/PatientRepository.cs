using DentalAssist.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalAssist.Services
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DentalAssistContext context) : base(context) { }

        public DentalAssistContext DentalAssistContext => Context as DentalAssistContext;

        public async Task<IEnumerable<Patient>> GetPatientsAsync(string searchString)
        {
            if(string.IsNullOrEmpty(searchString))
            {
                return await GetAllAsync();
            }

            return Find(p => p.FullName.StartsWith(searchString, StringComparison.CurrentCultureIgnoreCase));
        }

        public async Task<Patient> GetPatientAsync(int id)
        {
            return await Context.Set<Patient>().Where(p => p.PatientId == id).Include(p => p.DentalOperations).ThenInclude(p => p.DentalOperationItem).SingleOrDefaultAsync();
        }
    }
}
