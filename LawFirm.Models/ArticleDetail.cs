using LawFirm.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Models {
	public class ArticleDetail {
		public int Id { get; set; }

		public string Title { get; set; }

		public string Text { get; set; }

		public string ImagePath { get; set; }

		public DateTime CreationTime { get; set; }

		public int CategoryId { get; set; }

		public List<Comment> Comments { get; set; }

		public int Likes { get; set; }
	}
}
