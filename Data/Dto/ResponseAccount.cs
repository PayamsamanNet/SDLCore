using Common.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class ResponseAccount
    {
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public List<AccessDto> Access { get; set; }
        public string Errors { get; set; }
        public ResponseStatus status { get; set; }
    }
    public class ResponseAccount<Tdata> : ResponseAccount
    {
        public Tdata data { get; set; }
    }
}
