using Net4Sage;
using Net4Sage.CIUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMDataAccess.Datamodel;

namespace WMModuleUtils
{
    public class DispatchHandler : TransactionHandler
    {
        private WMDBContext dbContext;
        public DispatchHandler(ref SageSession session) : base(ref session)
        {
            TranType = 871;
            System.Data.EntityClient.EntityConnectionStringBuilder connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder()
            {
                Metadata = "res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = SysSession.GetConnectionString()
            };
            dbContext = new WMDBContext(connectionString.ToString());
        }
        public string GetNextDispatch()
        {
            return GetNextTransactionNumber();
        }
    }
}
