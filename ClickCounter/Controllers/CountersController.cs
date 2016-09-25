using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClickCounter.Models;
namespace ClickCounter.Controllers
{
    public class CountersController : Controller
    {
        //
        // GET: /Counters/
        [HttpGet]
        public ActionResult Index()
        {
            return View(CountersControllerVM.Instance.SelectCounter());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(int counterId)
        {
            if (CountersControllerVM.Instance.ClickCounter < CountersControllerVM.COUNTER_LIMIT)
            {
                CountersControllerVM.Instance.IterateCounter(counterId);
            }
            ModelState.Clear();
            return View(CountersControllerVM.Instance);
        }

    }
}
