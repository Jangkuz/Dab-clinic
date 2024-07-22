using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabClinicRepo.HelperClass
{
    public static class ErrorMessages
    {
        //ACC: Account
        //APP: Appointment
        //CLI: Clinic
        //SER: Service
        public static readonly Dictionary<string, string> Messages = new Dictionary<string, string>()
        {
            {"ACC001", "Wrong username or password" },
            {"ACC002", "Unauthorized login" },
            {"ACC003", "Username must be between 3 and 20 characters long" },
            {"ACC004", "Email must be a valid email" },
            {"ACC005", "Password must be between 3 and 10 characters long" },
            {"ACC006", "Fullname must be between 3 and 30 characters long" },
            {"ACC007", "Phone number must be a valid phone number" },

        };

        public const string UsernamePwdErr = "ACC001";
        public const string UsernameLengthErr = "ACC003";
        public const string EmailValidErr = "ACC004";
        public const string PwdLengthErr = "ACC005";
        public const string FullnameLengthErr = "ACC006";
        public const string PhonenumberValidErr = "ACC007";

    }
}
