using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalAssist.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository PatientRepository { get; }

        int SaveChanges();
    }
}
