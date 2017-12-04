using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace WebApiConduceSinPapeles.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UiController : Controller
    {
        // GET: Ui
        public ActionResult Index()
        {
            return View();
        }
    }
}