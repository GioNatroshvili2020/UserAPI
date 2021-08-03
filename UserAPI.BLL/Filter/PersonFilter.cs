using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.BLL.Filter
{
    public class PersonFilter :IFilter
    {
        public string? FullSearch { get; set; }
        public string? QuickSearch { get; set; }

        public int PageNumber { get; set; } = 1;        
        const int maxPageSize = 50;
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}
