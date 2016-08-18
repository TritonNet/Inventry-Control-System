using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Inventry_Control_System
{
    class SqlCon
    {
        public string ConnectionString()
        {
            return "Server=KUSHAN01;DataBase=InventoryControlSystem;Integrated Security=True;";
            
        }
    }
}
