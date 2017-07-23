using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Buru.Models;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Buru.BasecampApi;
using Buru.BasecampApi.Managers;
using System.Web.Script.Serialization;
using System.Web.Helpers;
using DotNet37Signals.Client.Basecamp;
using DotNet37Signals.Client.Basecamp.Contracts;
using DotNet37Signals.Client.Basecamp.Models;
using System.Configuration;
using DotNet37Signals.Client;
using System.Xml.Serialization;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace Buru.Controllers
{
    public class LoginController : Controller
    {
        private BuruDataEntities5 db = new BuruDataEntities5();
        string url = "https://launchpad.37signals.com/authorization/new?type=web_server&client_id={0}&redirect_uri={1}{2}";
        string reqToken = "https://launchpad.37signals.com/authorization/token?type=web_server&client_id={0}&redirect_uri={1}&client_secret={2}&code={3}"
        string client_id = "db0fb443b68995eb89d8152e4a5c779f7f5918ab";
        string client_secret = "c6356bef2cbcf98029be1577074a8052ffe22a35";
        string redirectURI = "http://localhost:54210/Home/Index";
        dynamic accessToken;
        string x;
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        // Authorization
        public string GetRequestAuthURL(Dictionary<string, string> optionalArguments = null)
        {
            string additional = string.Empty;
            if (optionalArguments != null)
            {
                System.Text.StringBuilder optional = new StringBuilder();
                foreach (var kv in optionalArguments)
                {
                    optional = optional.AppendFormat("&{0}={1}", System.Web.HttpUtility.UrlEncode(kv.Key), System.Web.HttpUtility.UrlEncode(kv.Value));
                }
                additional = optional.ToString();
                x = optional.ToString();
            }

            return string.Format(url, client_id, redirectURI, additional);
        }

        //GET Token
        public dynamic GetAccessToken(string code)
        {
            string TokenUrl = string.Format(reqToken, client_id, redirectURI, client_secret, code);
            var wr = System.Net.HttpWebRequest.Create(TokenUrl);
            wr.Method = "POST";
            var resp = (System.Net.HttpWebResponse)wr.GetResponse();
            using (var sw = new System.IO.StreamReader(resp.GetResponseStream()))
            {
                accessToken = JsonReader.Equals(sw.ReadToEnd);
            }
            return accessToken;
        }
            /*var credentials = new BasicAuthenticationCredentials()
            {
                AccountId = 3096040,
                UserName = "alifianif",
                Password = "050509ds"
            };

            Api api = new Api(credentials);
            var project = api.Projects.GetActive();*/

            /*var uname = ConfigurationManager.AppSettings["alifianif"];
            var pass = ConfigurationManager.AppSettings["050509ds"];
            var company = ConfigurationManager.AppSettings["Radya Labs"];
            var keepAliveEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["keepAliveEnabled"]);
            var maxReceivedMessageSize = Convert.ToInt32(ConfigurationManager.AppSettings["400"]);

            var credentials = new Credentials(uname, pass, company, keepAliveEnabled, maxReceivedMessageSize);
            var client = new BasecampClient(credentials);
            //Account account = client.Account.Get();
            var account = Equals(client.Account.Get());
            //var akun = account.Get();
            
            if (project == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            System.IO.File.WriteAllText(@"D:\Visual Studio\X.txt", Convert.ToString(project));
            return RedirectToAction("Index", "Home");
            //Akun akun = new Akun();
            //akun.AkunId = 

        }

    }
}
