using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Models.Entities {
	public class Comment : BaseEntity {

		public string Text { get; set; }

		public DateTime CreationTime { get; set; }
		

		public int ApplicationUserId { get; set; }

		public virtual List<Like> Likes { get; set; }

		public int LinkedCommentId { get; set; }

		public virtual Comment LinkedComment { get; set; }

		public int ArticleId { get; set; }

		public virtual Article Article { get; set; }
		
		public Type Type { get; set; }


		public Comment() {
			Likes = new List<Like>();
		}

	}
}
