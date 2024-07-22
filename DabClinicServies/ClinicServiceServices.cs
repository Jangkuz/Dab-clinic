using DabClinicRepo.HelperClass;
using DabClinicRepo.Models;
using DabClinicRepo.Repositories;
using Microsoft.IdentityModel.Tokens;
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
        public List<ClinicService> GetClinicServices(params Func<ClinicService, bool>[] conditions)
        {
            List<ClinicService> result = new();
            var filterConditions = conditions.ToList();

            if (filterConditions.IsNullOrEmpty())
            {
                filterConditions.Add(getAllServices => true);
            }

            try
            {
                result = _serviceRepo.FilterClinicServiceBasedOnCondition(Helper.CombineFilters(filterConditions))!;
            }
            catch (ArgumentNullException argEx)
            {
                ExceptionHelper.ConsoleWriteException("ClinicServiceServices_GetClinicServices", argEx);
            }

            return result;
        }
        //CRUD Service Category??
    }
}
