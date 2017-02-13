using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LawFirm.Models.Entities;

namespace LawFirm.Presenter.Models.CommentViewModels {
	public class CommentViewModel {
		public int Id { get; set; }
		public int ApplicationUserId { get; set; }
		public string Text { get; set; }
		public DateTime CreationTime { get; set; }
		public List<LikeViewModel> Likes { get; set; }
		public int LinkedCommentId { get; set; }
		public int ArticleId { get; set; }
		
	}
}