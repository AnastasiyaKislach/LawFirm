using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirm.Presenter.Models.BlogViewModels {
	public class CommentFormViewModel {

		public string Text { get; set; }

		public DateTime CreationTime { get; set; }

		public int LinkedCommentId { get; set; }

		public int ArticleId { get; set; }
	}
}