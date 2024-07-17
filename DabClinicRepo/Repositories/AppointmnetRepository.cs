using DabClinicRepo.Models;
using DabClinicRepo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Appointment>? GetAllAppointments()
        {
            List<Appointment>? appointments = null;
            using (_context = new())
            {
                appointments = _context.Appointments.Select(a => a).ToList();
            }
            return appointments;
        }
    }
}
