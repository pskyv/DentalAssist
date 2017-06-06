using DentalAssist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalAssist.Services
{
    public interface IDashboardRepository : IRepository<DentalOperation>
    {
        Task<List<GroupedDentalOperation>> GetGroupedDentalOperationsAsync();
    }
}
