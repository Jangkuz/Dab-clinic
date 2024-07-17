using DabClinicRepo.Models;
using DabClinicRepo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabClinicRepo.Repositories
{
    public class BookedServiceRepository
    {
        private DabClinicContext _context;
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
        public List<BookedService> GetAllBookedService()
        {
            List<BookedService> bookedServices = new List<BookedService>();

            return bookedServices;
        }

    }
}
