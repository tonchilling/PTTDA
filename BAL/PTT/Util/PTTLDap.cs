
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.PTT;
using DTO.DB;
using System.Web;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;

namespace BAL.PTT.Util
{
   public class PTTLDap
    {
       string DomainName= System.Configuration.ConfigurationSettings.AppSettings["LDAP"];

       public bool Authenticated(string domain,string username, string password)
       {
            string msg = "";
           DirectoryEntry entry;
           SearchResult result=null;

           try
           {
                msg += string.Format("Domain:{0} UserName:{1}/Password:xxx", domain, username);
               entry = new DirectoryEntry(@"LDAP://" + domain, username.Trim(), password.Trim(), AuthenticationTypes.Secure);
               // DirectoryEntry entry = new DirectoryEntry(@"LDAP://" + domain);
               DirectorySearcher search = new DirectorySearcher(entry);

               //SearchResultCollection all = search.FindAll();
               search.Filter = "(SAMAccountName=" + username + ")";

               search.PropertiesToLoad.Add("cn");

               result = search.FindOne();
           }
           catch (Exception ex)
           {
               Log("Login", "Error:", ex.ToString()+ msg);
           }
           return result != null ? true : false;

       }

        public string Authenticated2(string domain, string username, string password)
        {
            DirectoryEntry entry;
            SearchResult result = null;
            string name = "";
            try
            {
                entry = new DirectoryEntry(@"LDAP://" + domain, username, password, AuthenticationTypes.Secure);
                // DirectoryEntry entry = new DirectoryEntry(@"LDAP://" + domain);
                DirectorySearcher search = new DirectorySearcher(entry);

                //SearchResultCollection all = search.FindAll();
                search.Filter = "(SAMAccountName=" + username + ")";

                search.PropertiesToLoad.Add("cn");

                result = search.FindOne();


                foreach (string property in entry.Properties.PropertyNames)
                {
                    name += string.Format("\t{0} : {1} ", property, entry.Properties[property][0]);
                }


                if (result.Properties.Contains("sn"))
                {
                    name = result.Properties["sn"][0].ToString();
                }
            }
            catch (Exception ex)
            {
                name = ex.Message + ex.StackTrace;
                // Log("Login", "Error", ex.ToString());
            }
            return name;

        }



        protected static void Log(string pageName,string level,string message)
    {
        LogDAO logDAO = new LogDAO();
        LogDTO dto = new LogDTO();
        dto.System = "LDAP";
        dto.Page = pageName;
        dto.Level = level;
        dto.Message = message;
        logDAO.Add(dto);
    }


     

    }
}
