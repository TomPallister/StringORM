using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringORM
{
    class Something
    {
        public static T SetUp<T>(SqlDataReader reader) where T : new()
        {
            while (reader.Read())
            {   

            }
        }
    }
}
