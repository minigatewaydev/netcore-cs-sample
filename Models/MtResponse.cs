using System;
using System.Collections.Generic;
using System.Text;

namespace MgNetcoreCsSample.Models
{
    public class MtResponse
    {
        public string Username { get; set; }
        public string ChargingPlan { get; set; }
        public string Message { get; set; }
        public int CreditDeducted { get; set; }
        public List<Mt> MtList { get; set; }
    }
}