using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using Buru.Models;
using System.Net;

namespace Buru.Controllers
{
    public class HomeController : Controller
    {
        private BuruDataEntities5 db = new BuruDataEntities5();

        string client_id = "db0fb443b68995eb89d8152e4a5c779f7f5918ab";
        string client_secret = "c6356bef2cbcf98029be1577074a8052ffe22a35";
        string redirectURI = "http://localhost:54210/Home/Index";
        string accountURL = "https://launchpad.37signals.com/authorization.json";
        private static readonly HttpClient client = new HttpClient();

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var code = Request.Params["code"];
            string url = string.Format("https://launchpad.37signals.com/authorization/token?type=web_server&client_id=" + client_id + "&redirect_uri=" + redirectURI + "&client_secret=" + client_secret + "&code=" + code);
            var response = await client.PostAsync(url, null);
            var responseString = await response.Content.ReadAsStringAsync();
            var ReturnedToken = JsonConvert.DeserializeObject<Token>(responseString);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ReturnedToken.access_token);
            var reqauth = await client.GetStringAsync(accountURL);
            Models.Authorization account_id = JsonConvert.DeserializeObject<Models.Authorization>(reqauth);
            var id = getID(account_id, "Radya Labs");
            return View();
        }

        public String getID (Models.Authorization auth, string name)
        {
            foreach (var accounts in auth.accounts)
            {
                if (accounts.name == "Radya Labs")
                {
                    return accounts.id;
                }
            }
            return null;
        }

        /*public async System.Threading.Tasks.Task<string> getproject(string access_token, string id)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string url = String.Format("https://3.basecampapi.com/" + id + "/projects.json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var getpro = client.GetStringAsync(url);
            return getpro.Result;
        }*/

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}