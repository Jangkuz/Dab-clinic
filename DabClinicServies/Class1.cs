using DabClinicRepo.Repositories;
using DabClinicRepo.Models;

namespace DabClinicServies
{
    public class Class1
    {
        private AccountRepository _accountRepo = AccountRepository.GetInstance();
        public Class1()
        {
            
        }

        public void testMethod()
        {
            _accountRepo.AddAccount(new Account());
        }
    }
}
