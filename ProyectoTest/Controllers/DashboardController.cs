using ProyectoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;

namespace ProyectoTest.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DataDona()
        { 
            serieDona serie = new serieDona();
            return Json(serie.GetDataDummy(), JsonRequestBehavior.AllowGet);

            

        }

       

    }
}