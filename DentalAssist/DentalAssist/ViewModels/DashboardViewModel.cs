using DentalAssist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalAssist.ViewModels
{
    public class DashboardViewModel
    {
        public List<GroupedDentalOperation> GroupedDentalOperations { get; set; }
    }
}
