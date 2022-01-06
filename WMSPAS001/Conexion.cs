using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WMSPAS001
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
        public static List<string> GetConnectionStringNames()
        {
            List<string> cns = new List<string>();

            Configuration appconfig =

                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (ConnectionStringSettings cn in appconfig.ConnectionStrings.ConnectionStrings)
            {
                cns.Add(cn.Name);
            }
            return cns;
        }
    }
}
