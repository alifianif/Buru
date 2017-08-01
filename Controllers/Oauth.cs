using System;
using System.Web;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace Buru.Controllers
{
    public partial class Oauth : System.Web.UI.Page
    {
        public void Page_Load()
        {
            //string urls = Request.Url.Query;
            if (Request.Params["code"] != null)
            {
                var access_token = GetAccessToken();
                //Buru.BasecampApi.Api api = new Buru.BasecampApi.Api(access_token);
                //HttpClient httpclient = new HttpClient();
                //httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
                //JsonObject auth = httpclient.Get<JsonObject>("https://launchpad.37signals.com/authorization.json");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://launchpad.37signals.com/");
                request.ContentType = "/authorization.json; charset=utf-8";
                request.Headers["Authorization"] = "Basic " + access_token;
                request.PreAuthenticate = true;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    System.IO.File.WriteAllText(@"D:\Visual Studio\katanyasihjson.txt", reader.ReadToEnd());
                }
                //JsonObject me = api.Get<JsonObject>(string.Format("https://3.basecamp.com/{0}/projects.json", auth.id));
            }
        }

        private string GetAccessToken()
        {
            if (HttpRuntime.Cache["access_token"] == null)
            {
                Dictionary<string, string> args = GetOauthTokens(Request.Params["code"]);
                HttpRuntime.Cache.Insert("access_token", args["access_token"], null, DateTime.Now.AddMinutes(Convert.ToDouble(args["expires"])), TimeSpan.Zero);
            }
            return HttpRuntime.Cache["access_token"].ToString();
        }

        private Dictionary<string,string> GetOauthTokens(string code)
        {
            Dictionary<string, string> tokens = new Dictionary<string, string>();
            string clientId = "db0fb443b68995eb89d8152e4a5c779f7f5918ab";
            string redirectUrl = "http://localhost:54210/Buru/BasecampApi/Oauth.aspx";
            string client_secret = "c6356bef2cbcf98029be1577074a8052ffe22a35";

            string url = string.Format("https://launchpad.37signals.com/authorization/token?type=web_server&client_id={0}&redirect_uri={1}&client_secret={2}&code={3}",
                clientId, redirectUrl, client_secret, code);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string retVal = reader.ReadToEnd();

                foreach(string token in retVal.Split('&'))
                {
                    tokens.Add(token.Substring(0, token.IndexOf("=")),
                        token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                }
            }
            return tokens;
        }
    }
}