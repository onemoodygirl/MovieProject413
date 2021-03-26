using System;
using System.Collections.Generic; //had to manually add this. finally got rid of errors.
using System.Linq;
using System.Threading.Tasks;

//this is the temporary storage page

namespace Moody413Assignment3.Models
{
    public static class TempStorage
    {
        private static List<FormResponse> applications = new List<FormResponse>();

        public static IEnumerable<FormResponse> Applications => applications;

        public static void AddApplication(FormResponse application)
        {
            applications.Add(application);
        }
    }
}
