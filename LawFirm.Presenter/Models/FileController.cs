using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawFirm.Presenter.Models {
	public class FileController : Controller {
		public void Uploadnow(HttpPostedFileWrapper upload) {
			if (upload != null) {
				string imageName = upload.FileName;
				string path = System.IO.Path.Combine(Server.MapPath("~/Images/Uploads"), imageName);
				upload.SaveAs(path);
			}
		}

		public ActionResult UploadPartial() {
			var appData = Server.MapPath("~/Images/Uploads");
			var images = Directory.GetFiles(appData).Select(x => new ImageViewModel {
				Url = Url.Content("/Images/Uploads/" + Path.GetFileName(x))
			});
			return View("_UploadPartial", images);
		}
	}
}