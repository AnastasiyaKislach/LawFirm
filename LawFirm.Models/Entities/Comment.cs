using System;
using System.Collections.Generic;

namespace LawFirm.Models.Entities {
	public class Comment : BaseEntity {

		public string Text { get; set; }

		public DateTime CreationTime { get; set; }

		public string ApplicationUserId { get; set; }

		public virtual List<Like> Likes { get; set; }

		public int? ParentCommentId { get; set; }

		public int ArticleId { get; set; }

		public virtual Article Article { get; set; }
		
		public int Level { get; set; }

		public Comment() {
			Likes = new List<Like>();
		}

	}
}