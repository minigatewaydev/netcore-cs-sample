using System;
using System.Collections.Generic;
using System.Text;

namespace MgNetcoreCsSample.Models
{
   public class MtInfo
    {
        public string Text { get; set; }
        public string Encoding { get; set; }
        public int TotalPart { get; set; }
        public int TotalChar { get; set; }
        public bool DlrRequested { get; set; }
        public string DlrUrl { get; set; }
        public string ValidUntil { get; set; }
    }
}