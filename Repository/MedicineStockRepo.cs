using MedicineStockModule.Models;
using MedicineStockModule.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MedicineStockModule.Repository
{
    public class MedicineStockRepo:IMedicineStockRepo
    {
        readonly log4net.ILog _log4net;
        public MedicineStockRepo()
        {
            _log4net = log4net.LogManager.GetLogger(typeof(MedicineStockRepo));
        }

        private static List<MedicineStock> Medicines = new List<MedicineStock>
        {
            new MedicineStock{ Name= "Aciloc",ChemicalComposition="Domperidone,Omeprazole",TargetAilment="General",DateOfExpiry=new DateTime(2022,05,25),NumberOfTabletsInStock=1000},
            new MedicineStock{ Name= "Demerol",ChemicalComposition="Meperidine Hydrochloride,USP",TargetAilment="Orthopaedics",DateOfExpiry=new DateTime(2021,03,05),NumberOfTabletsInStock=2500},
            new MedicineStock{ Name= "Becosules",ChemicalComposition="Pyridoxine Hydrochloride,Thiamine,Nicotinamide,Folate",TargetAilment="General",DateOfExpiry=new DateTime(2023,12,28),NumberOfTabletsInStock=1500},
            new MedicineStock{ Name= "Cytotec",ChemicalComposition="Misoprostol,Prostaglandin E1 Analog",TargetAilment="Gynaecology",DateOfExpiry=new DateTime(2022,10,10),NumberOfTabletsInStock=1800},
            new MedicineStock{ Name= "Volini 50mg",ChemicalComposition="Diclofenac",TargetAilment="Orthopaedics",DateOfExpiry=new DateTime(2025,07,13),NumberOfTabletsInStock=600}
        };
        /// <summary>
        /// MedicineStockInformation method called by MedicinestockProvider
        /// </summary>
        /// <returns>return List of Medicines to MedicineStockProvider</returns>
        public List<MedicineStock> MedicineStockInformation()
        {
            try
            {
                _log4net.Info("MedicineStockRepository's MedicineStockInformation Action Method called for " + nameof(MedicineStockProvider));
                return Medicines;
            }
            catch(Exception e)
            {
                _log4net.Error(nameof(MedicineStockRepo) + "'s exception is" + e.Message);
                throw e;
            }
        }
    }
}
