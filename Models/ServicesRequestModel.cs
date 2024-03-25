using System.ComponentModel.DataAnnotations;

namespace NEXUS.Models
{
    public class ServicesRequestModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string AddressDetails { get; set; }

        public string City { get; set; }

        public string ServiceName { get; set; }

        public string Zip { get; set; }

        // Properties for Dial-Up Connection
        public string HourlyPlan { get; set; }
        public string Kbps28Plan { get; set; }
        public string Kbps56Plan { get; set; }

        // Properties for Broadband Connection
        public string BroadbandHourlyPlan { get; set; }
        public string Kbps64Plan { get; set; }
        public string Kbps128Plan { get; set; }

        // Properties for Land Line Connection
        public string LocalPlan { get; set; }
        public string StdPlan { get; set; }
    }
}




