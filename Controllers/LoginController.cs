using System;
using System.Web.Mvc;
using Buru.Models;
using System.Threading.Tasks;
using Buru.BasecampApi;
using System.Web.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.IO;
using System.Web.UI;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Buru.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Click()
        {
            _Default def = new _Default();
            def.btnAuthenticate_Click();
            return RedirectToAction("Index", "Home");
        }

    }
}
