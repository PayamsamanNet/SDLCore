using Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ApiResult
{
    public class ServiceResult
    {
        public ServiceResult(ResponseStatus statuscode,string? message)
        {
            if (message == null || message == "")
            {
                Message = EnumExtensions.GetEnumDescription(statuscode);
            }
            else
            {
                Message = message;
            }
            Status = statuscode;
        }
        public string Message { get; set; }
        public ResponseStatus Status { get; set; }
    }

}
