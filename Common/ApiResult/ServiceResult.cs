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
        public ServiceResult( ResponseStatus statuscode)
        {
            Message = EnumExtensions.GetEnumDescription(statuscode);
            Status = statuscode;
        }
        public string Message { get; set; }
        public ResponseStatus Status { get; set; }
    }

}
