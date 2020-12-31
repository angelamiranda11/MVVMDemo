using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Model
{
    class SingletonClass
    {
        public static readonly DatabaseClass databaseClass = new DatabaseClass();
    }
}
