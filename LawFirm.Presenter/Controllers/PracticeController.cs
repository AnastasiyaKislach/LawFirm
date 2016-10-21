using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawFirm.Presenter.Models;

namespace LawFirm.Presenter.Controllers
{
    public class PracticeController : Controller
    {
        // GET: Practice
        public ActionResult Index()
        {
			List<PracticeViewModel> practices = new List<PracticeViewModel>();
			for (int i = 0; i < 6; i++) {
				practices.Add(new PracticeViewModel {
					Id = i + 1,
					Title = "Bank And Financial",
					Text = "",
					ImagePath = String.Format("{0}/PracticeArea/{1}.jpg", Config.ImagesRootPath, "family-sitting")
				});
			}
            return View(practices);
        }

	    public ActionResult Details() {
			return View();
	    }
    }
}