using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buru.Controllers
{
    public partial class _Default : System.Web.UI.Page
    {
        public void btnAuthenticate_Click()
        {
            string client_id = "db0fb443b68995eb89d8152e4a5c779f7f5918ab";
            string redirectURI = "http://localhost:54210/Home/Index";
            string reqToken = "https://launchpad.37signals.com/authorization/token?type=web_server&client_id={0}&redirect_uri={1}&client_secret={2}&code={3}";

            var server = new DotNetOpenAuth.OAuth2.AuthorizationServerDescription();
            server.AuthorizationEndpoint = new Uri("https://launchpad.37signals.com/authorization/new?type=web_server&client_id={0}&redirect_uri={1}");
            server.TokenEndpoint = new Uri(reqToken);
            var client = new DotNetOpenAuth.OAuth2.WebServerClient(server, client_id, redirectURI);
            client.RequestUserAuthorization(returnTo: new Uri(redirectURI));

        }
    }
}