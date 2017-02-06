using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LawFirm.Presenter.Models.BlogViewModels;

namespace LawFirm.Presenter.Models {
	public class BlogView {
		public IEnumerable<ArticleViewModel> Articles { get; set; }

		public IEnumerable<CategoryViewModel> Categories { get; set; }
		
	}
}