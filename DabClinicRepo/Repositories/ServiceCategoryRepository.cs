using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DabClinicRepo.Models;
using DabClinicRepo.Context;

namespace DabClinicRepo.Repositories
{
    public class ServiceCategoryRepository
    {
        private DabClinicContext _context;
        private static ServiceCategoryRepository? _instance;
        private ServiceCategoryRepository()
        {
        }
        public static ServiceCategoryRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ServiceCategoryRepository();
            }
            return _instance;
        }

        public List<ServiceCategory> GetAllServiceCategories()
        {
            List<ServiceCategory> serviceCategories = new List<ServiceCategory>();

            return serviceCategories;
        }
    }
}
