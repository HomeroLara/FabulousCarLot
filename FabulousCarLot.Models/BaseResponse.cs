using System;
using System.Collections.Generic;
using System.Text;

namespace FabulousCarLot.Models
{
    public class BaseResponse
    {
        public string ErrorMessage { get; set; } = string.Empty;
        public int HttpResponseCode { get; set; }
    }
}
