using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettaSec.ASP.NET.Web.Core.Models
{
    public class ApiStatus<T>
    {
        public int statusCode { get; set; }
        public int? id { get; set; }
        public object json { get; set; }
        public List<T> data { get; set; }
        public int rowCount { get; set; } = 0;
        public object? errors { get; set; }
    }
}
