using System.Collections.Generic;
using PagedList;
using LawFirm.Models;
using System.Linq;
using LawFirm.Presenter.Models.BlogViewModels;

namespace LawFirm.Presenter.Models {

	public class BlogView {

		public IPagedList<ArticleInfo> ArticlesPage { get; set; }

		public IEnumerable<LastArticle> LastArticles { get; set; }

		public IEnumerable<CategoryViewModel> Categories { get; set; }

		public IEnumerable<ArchiveViewModel> ArchiveList { get; set; }

		public ArticleViewModel CurrentArticle { get; set; }
	}
}