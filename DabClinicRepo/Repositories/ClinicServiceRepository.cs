using DabClinicRepo.Models;
using DabClinicRepo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DabClinicRepo.HelperClass;
using Microsoft.EntityFrameworkCore;

namespace DabClinicRepo.Repositories
{
    public class ClinicServiceRepository
    {
        private DabClinicContext? _context;
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClinicService>? GetAllClinicServices()
        {
            List<ClinicService>? clinicServices = null;
            using (_context = new())
            {
                clinicServices = _context.ClinicServices.Select(a => a).ToList();
            }
            return clinicServices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public ClinicService? GetClinicServiceById(int id)
        {
            ClinicService? clinicServices = null;
            try
            {
                using (_context = new())
                {
                    clinicServices = _context.ClinicServices.FirstOrDefault(a => a.Id == id);
                }
            }
            catch (ArgumentException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }
            return clinicServices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterCondition"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public List<ClinicService>? FilterClinicServiceBasedOnCondition(Func<ClinicService, bool> filterCondition)
        {
            List<ClinicService>? clinicService = null;

            try
            {
                using (_context = new())
                {
                    clinicService = _context.ClinicServices.Where(filterCondition).ToList();
                }
            }
            catch (ArgumentNullException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }

            return clinicService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clinicService"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool AddClinicService(ClinicService clinicService)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.ClinicServices.Add(clinicService);
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
        /// <param name="clinicService"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool UpdateClinicService(ClinicService clinicService)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.ClinicServices.Update(clinicService);
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
        /// <param name="clinicService"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool DeleteClinicService(ClinicService clinicService)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.ClinicServices.Remove(clinicService);
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
