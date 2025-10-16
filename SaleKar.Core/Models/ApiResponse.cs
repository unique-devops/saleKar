using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleKar.Core.Models
{
    public class ApiResponse<T>
    {
        public bool is_success { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
