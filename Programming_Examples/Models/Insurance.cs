using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Examples.Models
{
    public class Insurance
    {
        public int InsuranceId { get; set; }
        public int PatientId { get; set; }
        public string? InsuranceCompany { get; set; }
        public string? PolicyNumber { get; set; }
    }
}
