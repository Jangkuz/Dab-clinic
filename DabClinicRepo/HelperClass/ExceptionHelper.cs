using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabClinicRepo.HelperClass
{
    public static  class ExceptionHelper
    {
        public static void ConsoleWriteException(string exceptionLocation, string type, Exception ex)
        {
            Console.WriteLine($"{exceptionLocation}{type}: {ex.Message}");
            Console.WriteLine($"Exception type: {ex.GetType()}");
        }

        public static void ConsoleWriteInnerException(Exception? innerException)
        {
            while (innerException != null) {
                Console.WriteLine($"Inner exception: {innerException.Message}");
                Console.WriteLine($"Inner exception type: {innerException.GetType()}");
                Console.WriteLine($"Inner exception stack trace: {innerException.StackTrace}");
                innerException = innerException.InnerException;
            }
        }
        public static bool IsDuplicateKeyException(DbUpdateException ex)
        {
            // Check if the InnerException is a SqlException and if it's a duplicate key violation
            if (ex.InnerException is SqlException sqlException)
            {
                // Error numbers 2627 and 2601 indicate unique constraint violations
                return sqlException.Number == 2627 || sqlException.Number == 2601;
            }
            return false;
        }

    }
}
