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

        public List<Account>? GetAllAcccounts()
        {
            List<Account>? accounts = null;

            using (_context = new())
            {
                accounts = _context.Accounts.Select(a => a).ToList();
            }

            return accounts;
        }

        public Account? GetAccountById(int id)
        {
            Account? account = null;

            using (_context = new())
            {
                account = _context.Accounts.FirstOrDefault(a => a.Id == id);
            }

            return account;
        }

        public Account? GetAccountByUsernamePassword(string usernamePassword, string password)
        {
            Account? account = null;

            using (_context = new())
            {
                //TODO: hash the string password before compare
                account = _context.Accounts.FirstOrDefault(a => a.Username == usernamePassword
                                                            && a.PasswordHash == password);
            }


            return account;
        }

        public Account? AddAccount(Account createdAccount)
        {
            using (_context = new())
            {
                _context.Accounts.Add(createdAccount);
                _context.SaveChanges();
            }
            return GetAccountById(createdAccount.Id);
        }

        public Account? UpdateAccount(Account updatedAccount)
        {
            using (_context = new())
            {
                _context.Accounts.Update(updatedAccount);
                _context.SaveChanges();
            }

            return GetAccountById(updatedAccount.Id);
        }

        public Account? DeleteAccount(Account deletedAccount)
        {

            using (_context = new())
            {
                _context.Accounts.Remove(deletedAccount);
                _context.SaveChanges();
            }

            return GetAccountById(deletedAccount.Id);
        }

    }
}
