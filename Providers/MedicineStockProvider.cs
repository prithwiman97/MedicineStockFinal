using MedicineStockModule.Controllers;
using MedicineStockModule.Models;
using MedicineStockModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStockModule.Providers
{
    public class MedicineStockProvider
    {
        readonly log4net.ILog _log4net;
        IMedicineStockRepo repoContext;
        public MedicineStockProvider(IMedicineStockRepo _repoContext)
        {
            repoContext = _repoContext;
            _log4net = log4net.LogManager.GetLogger(typeof(MedicineStockProvider));
        }
        /// <summary>
        /// MedicineStockInfo method called by MedicinestockController
        /// And in the MedicineStockInfo, Object of ImedicineRepo is calling MedicineStockInformation method and get List<MedicineStock> 
        /// </summary>
        /// <returns>return List of medicines which was getting by MedicineStockRepo to MedicineStockController</returns>
        public List<MedicineStock> MedicineStockInfo()
        {
            try
            {
                List<MedicineStock> medicines = repoContext.MedicineStockInformation();
                _log4net.Info("MedicineStockProvider's MedicineStockInfo Action Method called for " + nameof(MedicineStockController));
                _log4net.Info("MedicineStockRepository's MedicineStockInformation Action Method is calling for " + nameof(MedicineStockProvider));
                return medicines;
            }
            catch(Exception e)
            {
                _log4net.Error(nameof(MedicineStockProvider) + "'s exception is" + e.Message);
                throw e;
            }
        }
    }
}
