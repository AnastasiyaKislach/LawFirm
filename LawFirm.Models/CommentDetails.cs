using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawFirm.Models.Entities;

namespace LawFirm.Models {
	public class CommentDetails {
		public int Id { get; set; }

		public string Text { get; set; }

		public DateTime CreationTime { get; set; }

		public string ApplicationUserId { get; set; }

		public int Likes { get; set; }

		public int ParentCommentId { get; set; }

		public int ArticleId { get; set; }

		public List<Comment> Replies { get; set; }

		public int Level { get; set; }
	}
}
