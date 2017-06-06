using DentalAssist.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalAssist.Services
{
    public class DashboardRepository : Repository<DentalOperation>, IDashboardRepository
    {
        public DashboardRepository(DentalAssistContext context) : base(context) { }

        public DentalAssistContext DentalAssistContext => Context as DentalAssistContext;

        public async Task<List<GroupedDentalOperation>> GetGroupedDentalOperationsAsync()
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var query = from d in DentalAssistContext.DentalOperations
                        where d.StarDate >= startDate && d.StarDate <= endDate
                        group d by d.DentalOperationItem.Description into g                        
                        select new GroupedDentalOperation { DentalOperationName = g.Key, Count = g.Count() };

            return await query.ToListAsync();
        }
    }
}
