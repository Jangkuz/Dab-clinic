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
    public class AccountRepository
    {
        private DabClinicContext? _context;
        private static AccountRepository? _instance;
        private AccountRepository()
        {
        }
        public static AccountRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AccountRepository();
            }
            return _instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public List<Account>? GetAllAcccounts()
        {
            List<Account>? accounts = null;

            try
            {
                using (_context = new())
                {
                    accounts = _context.Accounts.Select(a => a).ToList();
                }
            }
            catch (ArgumentNullException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }

            return accounts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public Account? GetAccountById(int id)
        {
            Account? account = null;

            try
            {
                using (_context = new())
                {
                    account = _context.Accounts.FirstOrDefault(a => a.Id == id);
                }
            }
            catch (ArgumentNullException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }

            return account;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usernamePassword"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public Account? GetAccountByUsernamePassword(string usernamePassword, string password)
        {
            Account? account = null;

            try
            {
                using (_context = new())
                {
                    //TODO: hash the string password before compare
                    account = _context.Accounts.FirstOrDefault(a => a.Username == usernamePassword
                                                                && a.PasswordHash == password);
                }
            }
            catch (ArgumentNullException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }


            return account;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterCondition"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public List<Account>? FilterAccountBasedOnCondition(Func<Account, bool> filterCondition) { 
            List<Account>? accounts = null;

            try
            {
                using( _context = new())
                {
                    accounts = _context.Accounts.Where(filterCondition).ToList();
                }
            }
            catch (ArgumentNullException argEx)
            {
                ExceptionHelper.ConsoleWriteInnerException(argEx);
                throw;
            }

            return accounts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool AddAccount(Account account)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.Accounts.Add(account);
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
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool UpdateAccount(Account account)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.Accounts.Update(account);
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
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateConcurrencyException"/>
        /// <exception cref="DbUpdateException"/>
        public bool DeleteAccount(Account account)
        {
            var result = false;
            try
            {
                using (_context = new())
                {
                    _context.Accounts.Remove(account);
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

    }
}
