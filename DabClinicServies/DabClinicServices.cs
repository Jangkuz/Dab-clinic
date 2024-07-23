using DabClinicRepo.Enums;
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
    public class DabClinicServices
    {
        private ClinicRepository _clinicRepo;
        private AppointmnetRepository _appointmnetRepo;
        private ClinicSlotRepository _clinicSlotRepo;

        public DabClinicServices()
        {
            _clinicRepo = ClinicRepository.GetInstance();
            _appointmnetRepo = AppointmnetRepository.GetInstance();
            _clinicSlotRepo = ClinicSlotRepository.GetInstance();   
        }


        //Get Clinic detail
        //CRUD clinic slot??

    }
}
