using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Setting
{
    public sealed class SettingWeb
    {
        public int ExpireTimeSpan { get; set; }
        public string LoginPath { get; set; }
        public string LogoutPath { get; set; }
        public string AccessDeniedPath { get; set; }
        public string Name { get; set; }
        public string BaseAddress { get; set; }
        public string ClinetName { get; set; }
        public string TokenName { get; set; }
        public string TokenType { get; set; }

    }
}
