using Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Permission:BaseEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int? SubCode { get; set; }
        public bool IsMenu { get; set; }
        public int Code { get; set; }
    }
}
