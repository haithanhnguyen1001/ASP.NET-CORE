using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SV21T1020712.DomainModels;

namespace SV21T1020712.Web.Models
{
    public class OrderSearchResult : PaginationSearchResult
    {
        public int Status { get; set; } = 0;
        public string TimeRange { get; set; } = "";
        public List<Order> Data { get; set; } = new List<Order>();
    }
}