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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClinicSlot>? GetAllClinicSlots()
        {
            List<ClinicSlot>? clinicSlots = null;
            using (_context = new())
            {
                clinicSlots = _context.ClinicSlots.Select(a => a).ToList();
            }
            return clinicSlots;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public ClinicSlot? GetClinicSlotById(int id)
        {
            ClinicSlot? clinicSlots = null;
            try
            {
                using (_context = new())
                {
                    clinicSlots = _context.ClinicSlots.FirstOrDefault(a => a.SlotId == id);
                }
            }
            catch (ArgumentException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }
            return clinicSlots;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterCondition"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public List<ClinicSlot>? FilterClinicSlotBasedOnCondition(Func<ClinicSlot, bool> filterCondition)
        {
            List<ClinicSlot>? clinicSlot = null;

            try
            {
                using (_context = new())
                {
                    clinicSlot = _context.ClinicSlots.Where(filterCondition).ToList();
                }
            }
            catch (ArgumentNullException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }

            return clinicSlot;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clinicSlot"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool AddClinicSlot(ClinicSlot clinicSlot)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.ClinicSlots.Add(clinicSlot);
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
        /// <param name="clinicSlot"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool UpdateClinicSlot(ClinicSlot clinicSlot)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.ClinicSlots.Update(clinicSlot);
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
        /// <param name="clinicSlot"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool DeleteClinicSlot(ClinicSlot clinicSlot)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.ClinicSlots.Remove(clinicSlot);
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
