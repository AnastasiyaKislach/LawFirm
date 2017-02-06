using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawFirm.Presenter.Models;

namespace LawFirm.Presenter.Controllers {
	public class ContactsController : BaseController {
		// GET: Contacts
		public ActionResult Index() {
			return View();
		}

		public ActionResult FeedBack(FeedBackViewModel model) {
			if (ModelState.IsValid) {

			}
			return View("Index");
		}
	}
}