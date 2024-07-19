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
    public class ClinicRepository
    {
        private DabClinicContext? _context;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Clinic>? GetAllClinics()
        {
            List<Clinic>? clinics = null;
            using (_context = new())
            {
                clinics = _context.Clinics.Select(a => a).ToList();
            }
            return clinics;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public Clinic? GetClinicById(int id)
        {
            Clinic? clinics = null;
            try
            {
                using (_context = new())
                {
                    clinics = _context.Clinics.FirstOrDefault(a => a.ClinicId == id);
                }
            }
            catch (ArgumentException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }
            return clinics;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterCondition"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public List<Clinic>? FilterClinicBasedOnCondition(Func<Clinic, bool> filterCondition)
        {
            List<Clinic>? clinic = null;

            try
            {
                using (_context = new())
                {
                    clinic = _context.Clinics.Where(filterCondition).ToList();
                }
            }
            catch (ArgumentNullException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }

            return clinic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clinic"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool AddClinic(Clinic clinic)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.Clinics.Add(clinic);
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
        /// <param name="clinic"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool UpdateClinic(Clinic clinic)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.Clinics.Update(clinic);
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
        /// <param name="clinic"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool DeleteClinic(Clinic clinic)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.Clinics.Remove(clinic);
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
