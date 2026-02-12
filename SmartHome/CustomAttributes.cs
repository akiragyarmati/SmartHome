using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DeviceCategoryAttribute : Attribute
    {
        public string Category { get; }
        public int SecurityLevel { get; }

        public DeviceCategoryAttribute(string category, int securityLevel = 1)
        {
            Category = category;
            SecurityLevel = securityLevel;
        }

    }
}
