using OperatingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPCB(ProcessControlBlock pcb)
        {
            OperatingSystemProgram.ReadyQueue.AddProcess(pcb);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult StartProgram(int memorySize, AllocationStrategy strategy)
        {


            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
