using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WMCWO001
{
    class Conexion
    {
        public static void SaveConnectionString(string connectionStringName, string connectionString)
        {
            Configuration appconfig =

                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            appconfig.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString = connectionString;

            appconfig.Save();
        }
    }
}
