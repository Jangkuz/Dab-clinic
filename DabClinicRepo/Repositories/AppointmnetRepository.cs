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
    public class AppointmnetRepository
    {
        private DabClinicContext? _context;
        private static AppointmnetRepository? _instance;
        private AppointmnetRepository()
        {
        }
        public static AppointmnetRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AppointmnetRepository();
            }
            return _instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Appointment>? GetAllAppointments()
        {
            List<Appointment>? appointments = null;
                using (_context = new())
                {
                    appointments = _context.Appointments.Select(a => a).ToList();
                }
            return appointments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public Appointment? GetAppointmentById(int id)
        {
            Appointment? appointments = null;
            try
            {
                using (_context = new())
                {
                    appointments = _context.Appointments.FirstOrDefault(a => a.Id == id);
                }
            }
            catch (ArgumentException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }
            return appointments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterCondition"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public List<Appointment>? FilterAppointmentBasedOnCondition(Func<Appointment, bool> filterCondition)
        {
            List<Appointment>? appointment = null;

            try
            {
                using (_context = new())
                {
                    appointment = _context.Appointments.Where(filterCondition).ToList();
                }
            }
            catch (ArgumentNullException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }

            return appointment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool AddAppointmnet(Appointment appointment)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.Appointments.Add(appointment);
                    int writtenEntity = _context.SaveChanges();
                    if(writtenEntity > 0)
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
        /// <param name="appointment"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool UpdateAppointmnet(Appointment appointment)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.Appointments.Update(appointment);
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
        /// <param name="appointment"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool DeleteAppointmnet(Appointment appointment)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.Appointments.Remove(appointment);
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
