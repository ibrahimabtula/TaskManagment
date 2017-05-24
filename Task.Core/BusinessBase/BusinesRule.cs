using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Core
{
    public class BusinesRule
    {
        public string Property { get; set; }
        public string Description { get; set; }

        public BusinesRule(string Property, string Description)
        {
            this.Property = Property;
            this.Description = Description;
        }
    }
}
