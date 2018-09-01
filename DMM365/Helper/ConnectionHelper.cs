using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Xrm.Sdk;

namespace DMM365.Helper
{
    public static class ConnectionHelper
    {

        internal static CrmServiceClient  getOnLineConnection(string orgName, string serverName, string userName, string passowrd)
        {
            CrmServiceClient crmConn = new CrmServiceClient(userName, CrmServiceClient.MakeSecureString(passowrd), string.Empty, orgName, true, false, null, true);
            if (!crmConn.IsReady) {
                                
                //TO DO: log errors

                string lastError = crmConn.LastCrmError;
                Exception lastEx = crmConn.LastCrmException;
            }

            return crmConn;
        }

        //TO DO: on-prem and IFD
    }
}
