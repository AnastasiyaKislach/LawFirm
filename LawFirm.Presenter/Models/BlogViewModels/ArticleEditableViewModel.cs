using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawFirm.Presenter.Models.BlogViewModels {
	public class ArticleEditableViewModel {
		public IEnumerable<SelectListItem> Categories { get; set; }
		public ArticleViewModel RequestViewModel { get; set; }
	}
}