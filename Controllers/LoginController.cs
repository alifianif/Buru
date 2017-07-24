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
using System.IO;

namespace Buru.Controllers
{
    public class LoginController : Controller
    {
        private BuruDataEntities5 db = new BuruDataEntities5();
        string url = "https://launchpad.37signals.com/authorization/new?type=web_server&client_id={0}&redirect_uri={1}{2}";
        string reqToken = "https://launchpad.37signals.com/authorization/token?type=web_server&client_id={0}&redirect_uri={1}&client_secret={2}&code={3}";
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
        /*public string GetRequestAuthURL(Dictionary<string, string> optionalArguments = null)
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
                //x = optional.ToString();
                //System.IO.File.WriteAllText(@"D:\Visual Studio\Burucoba7.txt", additional);
            }

            return string.Format(url, client_id, redirectURI, additional);
        }

        //GET Token
        public void GetAccessToken()
        {
            var requrl = GetRequestAuthURL();
            var webrequest = System.Net.WebRequest.Create(requrl);
            if (webrequest != null)
            {
                webrequest.Method = "GET";
                webrequest.ContentType = "/authorization.json";
            }
            var resp = webrequest.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(resp);
            //string responsefromserver = reader.ReadToEnd;
            System.IO.File.WriteAllText(@"D:\Visual Studio\Burucoba6.txt", Convert.ToString(reader));

            string TokenUrl = string.Format(reqToken, client_id, redirectURI, client_secret, x);
            System.IO.File.WriteAllText(@"D:\Visual Studio\Burucoba5.txt", TokenUrl);
            var wr = System.Net.WebRequest.Create(TokenUrl);
            if (wr != null)
            {
                wr.Method = "POST";
                wr.Timeout = 20000;
                wr.ContentType = "/authorization.json";
            }
            //var resp = (System.Net.HttpWebResponse)wr.GetResponse();
            using (System.IO.Stream s = wr.GetResponse().GetResponseStream()) 
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                {
                    var jsonResponse = sr.ReadToEnd();
                    accessToken = jsonResponse;
                    System.IO.File.WriteAllText(@"D:\Visual Studio\Burucoba1.txt", jsonResponse);
                }
            }
            //return accessToken;
        }*/

        //Login
        public ActionResult Click()
        {
            var server = new DotNetOpenAuth.OAuth2.AuthorizationServerDescription();
            server.AuthorizationEndpoint = new Uri(url);
            server.TokenEndpoint = new Uri(reqToken);
            //var token = server.TokenEndpoint.
            var client = new DotNetOpenAuth.OAuth2.WebServerClient(server, client_id, client_secret);
            client.RequestUserAuthorization(returnTo: new Uri(redirectURI));
            //client.RequestUserAuthorization(returnTo: new Uri();
            //var token = client.GetClientAccessToken().AccessToken;
            //System.IO.File.WriteAllText(@"D:\Visual Studio\a.txt", token);
            return RedirectToAction("Index", "Home");
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
            //System.IO.File.WriteAllText(@"D:\Visual Studio\X.txt", Convert.ToString(project));
            //return RedirectToAction("Index", "Home");
            //Akun akun = new Akun();
            //akun.AkunId = 

        }

    }
//}
