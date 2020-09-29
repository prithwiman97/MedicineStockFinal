using MedicineStockModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStockModule.Repository
{
    public interface IMedicineStockRepo
    {
      public List<MedicineStock> MedicineStockInformation();
    }
}
