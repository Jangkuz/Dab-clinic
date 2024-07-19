using DabClinicRepo.Enums;
using DabClinicRepo.HelperClass;
using DabClinicRepo.Models;
using DabClinicRepo.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DabClinicServies
{
    public class AccountServices
    {
        private AccountRepository _accountRepo;

        public AccountServices()
        {
            _accountRepo = AccountRepository.GetInstance();
        }

        public bool Login(string username, string password, out Account? loginAccount, out List<string> errors)
        {
            bool result = false;
            loginAccount = null;
            errors = new();
            try
            {
                if (!username.IsNullOrEmpty() &&
                    !password.IsNullOrEmpty())
                {
                    loginAccount = _accountRepo.GetAccountByUsernamePassword(username, password);
                }
                else
                {
                    errors.Add(ErrorMessages.UsernamePwdErr);
                }
            }
            catch (ArgumentNullException argEx)
            {
                ExceptionHelper.ConsoleWriteException("AccountServices_Login", argEx);
            }
            return result;
        }

        public bool Signup(Account signupAccount, out List<string> errors)
        {
            //validate, set error message, 
            bool result = false;
            errors = new();

            Account validAccount = new();

            try
            {
                //2. check all user errors
                if (AccountValidateHelper.IsValidAccount(signupAccount, out validAccount, out errors))
                {
                    result = _accountRepo.AddAccount(validAccount);
                }
            }
            catch (DbUpdateConcurrencyException dbuConEx)
            {
                ExceptionHelper.ConsoleWriteException("AccountServices_Signup", dbuConEx);
            }
            catch (DbUpdateException dbuEx)
            {
                ExceptionHelper.ConsoleWriteException("AccountServices_Signup", dbuEx);
            }

            return result;
        }

        public List<Account> GetDentisList(params Func<Account, bool>[] conditions)
        {
            //based on condition
            List<Account> result = new();
            var filterConditions = conditions.ToList();

            //default condition
            filterConditions.Add(account => account.Role == Role.Staff);
            try
            {
                result = _accountRepo.FilterAccountBasedOnConditions(Helper.CombineFilters(filterConditions));
            }
            catch (ArgumentNullException argEx)
            {
                ExceptionHelper.ConsoleWriteException("AccountServices_GetDentisList", argEx);
            }

            return result;
        }

        public bool ManageAccount(Account updateAccount, List<string> errors)
        {
            //update account info
            //validate, set error message, 
            bool result = false;
            errors = new();

            Account validAccount = new();

            try
            {
                //2. check all user errors
                if (AccountValidateHelper.IsValidAccount(updateAccount, out validAccount, out errors))
                {
                    result = _accountRepo.UpdateAccount(validAccount);
                }
            }
            catch (DbUpdateConcurrencyException dbuConEx)
            {
                ExceptionHelper.ConsoleWriteException("AccountServices_Signup", dbuConEx);
            }
            catch (DbUpdateException dbuEx)
            {
                ExceptionHelper.ConsoleWriteException("AccountServices_Signup", dbuEx);
            }

            return result;
        }

        public void GetAccountScheduledPage()
        {

        }

        public void GetAccountAppointmentList()
        {

        }

        public void BookAnAppointment()
        {

        }

    }
}
