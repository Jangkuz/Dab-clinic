using DabClinicRepo.Enums;
using DabClinicRepo.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DabClinicRepo.HelperClass
{
    public static class AccountValidateHelper
    {
        public static bool IsValidAccount(Account signupAccount, out Account validAccount, out List<string> errors)
        {
            bool result = false;
            bool foundErr = false;
            validAccount = new();
            errors = new();
            string username = signupAccount.Username;
            string email = signupAccount.Email;
            string pwd = signupAccount.PasswordHash;
            DateTime creationTime = DateTime.Now;
            string? fullname = signupAccount.Fullname;
            DateOnly? birthdate = signupAccount.Birthdate;
            string? gender = signupAccount.Gender;
            string? phone = signupAccount.Phone;
            bool activated = true;
            bool removed = false;

            if (!IsValidUsername(username))
            {
                foundErr = true;
                errors.Add(ErrorMessages.UsernameLengthErr);
            }
            if (!IsValidEmail(email))
            {
                foundErr = true;
                errors.Add(ErrorMessages.EmailValidErr);
            }
            if (!IsValidPassword(pwd))
            {
                foundErr = true;
                errors.Add(ErrorMessages.PwdLengthErr);
            }
            if (!IsValidFullName(fullname))
            {
                foundErr = true;
                errors.Add(ErrorMessages.FullnameLengthErr);
            }

            //if (string.IsNullOrEmpty(gender)) {
            //    gender = Gender.Male;
            //}

            if (!IsValidPhoneNumber(phone))
            {
                foundErr = true;
                errors.Add(ErrorMessages.PhonenumberValidErr);
            }

            if (!foundErr)
            {
                result = true;
                validAccount = new()
                {
                    Username = username,
                    Email = email,
                    PasswordHash = pwd, //TODO: make password hasher
                    CreationTime = creationTime,
                    Fullname = fullname,
                    Birthdate = birthdate,
                    Gender = gender,
                    Phone = phone,
                    Active = activated,
                    Removed = removed
                };
            }
            return result;
        }

        public static bool IsValidUsername(string username)
        {
            if (username.Trim().Length < 3 ||
                20 < username.Trim().Length)
            {
                return false;
            }

            return true;
        }
        public static bool IsValidEmail(string email)
        {
            //Chat GPT-ed
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        public static bool IsValidPassword(string pwd)
        {
            if (pwd.Trim().Length < 3 ||
                10 < pwd.Trim().Length)
            {
                return false;
            }

            return true;
        }
        public static bool IsValidFullName(string fullname)
        {
            if (fullname.Trim().Length < 3 ||
                30 < fullname.Trim().Length)
            {
                return false;
            }

            return true;
        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            //Chat GPT-ed
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // This regex matches most international phone number formats
            string pattern = @"^\+?[1-9]\d{1,14}$";

            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}
