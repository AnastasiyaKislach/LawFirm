using System;
using System.Collections.Generic;
using LawFirm.Presenter.Models.BlogViewModels;

namespace LawFirm.Presenter.Models.CommentViewModels {
	public class CommentViewModel {
		public int Id { get; set; }

		public string ApplicationUserId { get; set; }

		public string ApplicationUserName { get; set; }

		public string Text { get; set; }

		public DateTime CreationTime { get; set; }

		public LikeViewModel Likes { get; set; }

		public List<CommentViewModel> Replies { get; set; }

		public int? ParentCommentId { get; set; }

		public int ArticleId { get; set; }

		public int Level { get; set; }

		public CommentViewModel() {
			Replies = new List<CommentViewModel>();
		}
	}
}