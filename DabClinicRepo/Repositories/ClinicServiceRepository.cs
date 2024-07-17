using DabClinicRepo.Models;
using DabClinicRepo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabClinicRepo.Repositories
{
    public class ClinicServiceRepository
    {
        private DabClinicContext _context;
        private static ClinicServiceRepository? _instance;
        private ClinicServiceRepository()
        {
        }
        public static ClinicServiceRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClinicServiceRepository();
            }
            return _instance;
        }
        public List<ClinicService> GetAllClinicServices()
        {
            List<ClinicService> clinics = new List<ClinicService>();

            return clinics;
        }
    }
}
