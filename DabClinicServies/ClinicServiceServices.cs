using DabClinicRepo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabClinicServies
{
    public class ClinicServiceServices
    {
        private ClinicServiceRepository _serviceRepo;
        private ServiceCategoryRepository _categoryRepo;

        public ClinicServiceServices()
        {
            _serviceRepo = ClinicServiceRepository.GetInstance();
            _categoryRepo = ServiceCategoryRepository.GetInstance();
        }

        //CRUD Clinic Service??
        //CRUD Service Category??
    }
}
