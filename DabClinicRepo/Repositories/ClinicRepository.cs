using DabClinicRepo.Models;
using DabClinicRepo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabClinicRepo.Repositories
{
    public class ClinicRepository
    {
        private DabClinicContext _context;
        private static ClinicRepository? _instance;
        private ClinicRepository()
        {
        }
        public static ClinicRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClinicRepository();
            }
            return _instance;
        }
        public List<Clinic> GetAllClinics()
        {
            List<Clinic> clinics = new List<Clinic>();

            return clinics;
        }
    }
}
