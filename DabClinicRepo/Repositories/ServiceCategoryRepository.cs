using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DabClinicRepo.Models;
using DabClinicRepo.Context;
using DabClinicRepo.HelperClass;
using Microsoft.EntityFrameworkCore;

namespace DabClinicRepo.Repositories
{
    public class ServiceCategoryRepository
    {
        private DabClinicContext? _context;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ServiceCategory>? GetAllServiceCategorys()
        {
            List<ServiceCategory>? serviceCategorys = null;
            using (_context = new())
            {
                serviceCategorys = _context.ServiceCategories.Select(a => a).ToList();
            }
            return serviceCategorys;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public ServiceCategory? GetServiceCategoryById(int id)
        {
            ServiceCategory? serviceCategorys = null;
            try
            {
                using (_context = new())
                {
                    serviceCategorys = _context.ServiceCategories.FirstOrDefault(a => a.Id == id);
                }
            }
            catch (ArgumentException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }
            return serviceCategorys;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterCondition"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public List<ServiceCategory>? FilterServiceCategoryBasedOnCondition(Func<ServiceCategory, bool> filterCondition)
        {
            List<ServiceCategory>? serviceCategory = null;

            try
            {
                using (_context = new())
                {
                    serviceCategory = _context.ServiceCategories.Where(filterCondition).ToList();
                }
            }
            catch (ArgumentNullException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }

            return serviceCategory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCategory"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool AddServiceCategory(ServiceCategory serviceCategory)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.ServiceCategories.Add(serviceCategory);
                    int writtenEntity = _context.SaveChanges();
                    if (writtenEntity > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (DbUpdateConcurrencyException dbuConEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(dbuConEx);
                throw;
            }
            catch (DbUpdateException dbuEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(dbuEx);
                throw;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCategory"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool UpdateServiceCategory(ServiceCategory serviceCategory)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.ServiceCategories.Update(serviceCategory);
                    int writtenEntity = _context.SaveChanges();
                    if (writtenEntity > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (DbUpdateConcurrencyException dbuConEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(dbuConEx);
                throw;
            }
            catch (DbUpdateException dbuEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(dbuEx);
                throw;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCategory"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool DeleteServiceCategory(ServiceCategory serviceCategory)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.ServiceCategories.Remove(serviceCategory);
                    int writtenEntity = _context.SaveChanges();
                    if (writtenEntity > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (DbUpdateConcurrencyException dbuConEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(dbuConEx);
                throw;
            }
            catch (DbUpdateException dbuEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(dbuEx);
                throw;
            }
            return result;
        }
    }
}
