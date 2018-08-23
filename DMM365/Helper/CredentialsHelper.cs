using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredentialManagement;
using System.Security;

namespace DMM365.Helper
{
    public static class CredentialsHelper
    {

        internal static bool setLocalCredentials(string orgName, string serverName, string userName, string password, string description = "")
        {
            string target = string.Concat(orgName, serverName, userName);

            if (getLocalPassword(target) == password) return true;
            else return savePasswordLocaly(target, userName, password, description);

        }

        /// <summary>
        /// By default Target is combination of crm org name, server name  and user name.
        /// Use same combination to pool credentials
        /// </summary>
        /// <param name="target"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        private static bool savePasswordLocaly(string target, string userName, string password, string description = "")
        {
            using (var windowsCred = new Credential())
            {
                windowsCred.Target = target;
                windowsCred.Username = userName;
                windowsCred.Password = password;
                windowsCred.Type = CredentialType.Generic;
                windowsCred.PersistanceType = PersistanceType.LocalComputer;
                return windowsCred.Save();
            }
        }

        /// <summary>
        /// By default Target is combination of  crm org name, server name  and user name.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        internal static string getLocalPassword(string target)
        {
            using (var windowsCred = new Credential())
            {
                windowsCred.Target = target;
                if (!windowsCred.Load()) return null;
                else return windowsCred.Password;
            }
        }

        /// <summary>
        /// By default Target is combination of  crm org name, server name  and user name.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        internal static bool removeLocalCredentials(string target)
        {
            return new Credential { Target = target }.Delete();
        }
    }
}
