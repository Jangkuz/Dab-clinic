﻿using DabClinicRepo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabClinicServies
{
    public class ClinicServices
    {
        private ClinicRepository _clinicRepo;
        private AppointmnetRepository _appointmnetRepo;
        private ClinicSlotRepository _clinicSlotRepo;

        public ClinicServices()
        {
            _clinicRepo = ClinicRepository.GetInstance();
            _appointmnetRepo = AppointmnetRepository.GetInstance();
            _clinicSlotRepo = ClinicSlotRepository.GetInstance();   
        }

        //Get Clinic detail
        //CRUD clinic slot??

    }
}
