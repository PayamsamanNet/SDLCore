using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities.ClassUtilities
{
    public  class ControllerModel
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsMenu { get; set; } = false;
        public List<ListActions> Actions { get; set; }
    }

    public class ListActions
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public int  NumberMenu { get; set; }
        public string Url { get; set; }
        private bool IsMenu { get; set; } = false;
    }
}
