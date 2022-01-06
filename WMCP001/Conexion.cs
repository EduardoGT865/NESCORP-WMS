using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WMCP001
{
    class Conexion
    {
        public static string GetConnectionString(string connectionStringName)
        {
            Configuration appconfig =

                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConnectionStringSettings connStringSettings = appconfig.ConnectionStrings.ConnectionStrings[connectionStringName];

            return connStringSettings.ConnectionString;
        }
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
        public static string GetFirstConnectionStringName()
        {
            return GetConnectionStringNames().FirstOrDefault();
        }
    }
}
