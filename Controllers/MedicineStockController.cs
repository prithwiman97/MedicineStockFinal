using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineStockModule.Models;
using MedicineStockModule.Providers;
using MedicineStockModule.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MedicineStockModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicineStockController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        MedicineStockProvider providerContext;
       

        public MedicineStockController(MedicineStockProvider _providerContext)
        {
            providerContext = _providerContext;
            _log4net = log4net.LogManager.GetLogger(typeof(MedicineStockController));
        }

        /// <summary>
        /// Get method called by api
        /// In the Get method,object of prvider is calling MedicineStockInfo method and check about the MedicineList 
        /// </summary>
        /// <returns>return List of medicines to Api</returns>
        [HttpGet]
        public IActionResult Get()
        {
            _log4net.Info("MedicineStockController  Action Method called");
            try
            {
                _log4net.Info("MedicineStockProvider's MedicineStockInfo is calling for " + nameof(MedicineStockController));
                List<MedicineStock> medicinelist = providerContext.MedicineStockInfo();
                if (medicinelist == null)
                {
                    _log4net.Error("Database is empty"+nameof(MedicineStockController));
                    return NotFound("MedicineStock is empty");
                }
                _log4net.Info("MedicineStockRepository's MedicineStockInformation works for " + nameof(MedicineStockProvider));
                _log4net.Info("MedicineStockProvider's MedicineStockInfo works for " + nameof(MedicineStockController));
                return Ok(medicinelist);
            }
            catch (Exception e)
            {
                _log4net.Error(nameof(MedicineStockController)+"'s exception is"+e.Message);
                return StatusCode(500);
            }
        }
    }
}
