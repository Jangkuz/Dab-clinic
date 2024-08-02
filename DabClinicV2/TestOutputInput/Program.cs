using DabClinic.Domain.IService;
using DabClinic.Domain.Models;
using DabClinic.EntityFramework.Services;

namespace TestOutputInput
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDataService<ServiceCategory> clinicServices = new GenericDataService<ServiceCategory>(new DabClinic.EntityFramework.Context.DabClinicDbContextFactory());

            Console.WriteLine(clinicServices.);

            Console.ReadLine();
        }
    }
}
