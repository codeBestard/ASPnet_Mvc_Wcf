using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdDataAggregation.Models
{
    public class AdDTO
    {
        public int AdId         { get; set; }
        public int BrandId      { get; set; }
        public String BrandName { get; set; }
        public Decimal NumPages { get; set; }
        public string Position  { get; set; }
    }
}