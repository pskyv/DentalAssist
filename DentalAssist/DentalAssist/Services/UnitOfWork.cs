using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalAssist.Models;

namespace DentalAssist.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DentalAssistContext _context;

        public UnitOfWork(DentalAssistContext context)
        {
            _context = context;
            PatientRepository = new PatientRepository(_context);
        }
        
        public IPatientRepository PatientRepository { get; }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
