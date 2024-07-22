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
    public class BookedServiceRepository
    {
        private DabClinicContext? _context;
        private static BookedServiceRepository? _instance;
        private BookedServiceRepository()
        {
        }
        public static BookedServiceRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BookedServiceRepository();
            }
            return _instance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<BookedService>? GetAllBookedServices()
        {
            List<BookedService>? bookedServices = null;
            using (_context = new())
            {
                bookedServices = _context.BookedServices.Select(a => a).ToList();
            }
            return bookedServices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public BookedService? GetBookedServiceById(int id)
        {
            BookedService? bookedServices = null;
            try
            {
                using (_context = new())
                {
                    bookedServices = _context.BookedServices.FirstOrDefault(a => a.Id == id);
                }
            }
            catch (ArgumentException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }
            return bookedServices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterCondition"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public List<BookedService>? FilterBookedServiceBasedOnCondition(Func<BookedService, bool> filterCondition)
        {
            List<BookedService>? bookedService = null;

            try
            {
                using (_context = new())
                {
                    bookedService = _context.BookedServices.Where(filterCondition).ToList();
                }
            }
            catch (ArgumentNullException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }

            return bookedService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookedService"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool AddBookedService(BookedService bookedService)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.BookedServices.Add(bookedService);
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
        /// <param name="bookedService"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool UpdateBookedService(BookedService bookedService)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.BookedServices.Update(bookedService);
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
        /// <param name="bookedService"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool DeleteBookedService(BookedService bookedService)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.BookedServices.Remove(bookedService);
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
