using System;
using System.Collections.Generic;
using System.Text;

namespace Inventry_Control_System
{
    class OledbCon
    {
        public string ConnectionString()
        {
            return @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Northwind.mdb";
        }
    }
}
