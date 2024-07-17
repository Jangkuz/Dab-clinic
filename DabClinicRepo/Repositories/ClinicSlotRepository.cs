using DabClinicRepo.Models;
using DabClinicRepo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabClinicRepo.Repositories
{
    public class ClinicSlotRepository
    {
        private DabClinicContext _context;
        private static ClinicSlotRepository? _instance;
        private ClinicSlotRepository()
        {
        }
        public static ClinicSlotRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClinicSlotRepository();
            }
            return _instance;
        }
        public List<ClinicService> GetAllClinicService()
        {
            List<ClinicService> clinicServices = new List<ClinicService>();

            return clinicServices;
        }
    }
}
