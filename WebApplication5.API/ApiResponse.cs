using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.API
{
    public class ApiResponse<T>
    {
        public string code { get; set; }
        public string status { get; set; }
        public string message { get; set; }
 public T Response{ get; set; }
    }
}
