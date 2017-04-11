using System;

namespace LawFirm.Models {

	public class ArticleInfo {

		public int Id { get; set; }

		public string Title { get; set; }

		public string Text { get; set; }

		public string ImagePath { get; set; }

		public DateTime CreationTime { get; set; }

		public int Likes { get; set; }

		public int Comments { get; set; }
	}
}