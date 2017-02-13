using LawFirm.Presenter.Models.CommentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirm.Presenter.Models.BlogViewModels {
	public class ArticleViewModel {
		public int Id { get; set; }

		public string Title { get; set; }

		public string Text { get; set; }

		public string ImagePath { get; set; }

		public DateTime CreationTime { get; set; }

		public int CategoryId { get; set; }

		public List<LikeViewModel> Likes { get; set; }

		public List<CommentViewModel> Comments { get; set; }
	}
}