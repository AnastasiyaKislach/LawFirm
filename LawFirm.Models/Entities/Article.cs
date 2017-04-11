using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Models.Entities {
	public class Article : BaseEntity {
		public string Title { get; set; }

		public string Text { get; set; }

		public string ImagePath { get; set; }

		public DateTime CreationTime { get; set; }

		public int CategoryId { get; set; }

		public virtual Category Category { get; set; }

		public virtual List<Comment> Comments { get; set; }

		public virtual List<Like> Likes { get; set; }

		public Article() {
			Comments = new List<Comment>();
			Likes = new List<Like>();
		}
	}
}
