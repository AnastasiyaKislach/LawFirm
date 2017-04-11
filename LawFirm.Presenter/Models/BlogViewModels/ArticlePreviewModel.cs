using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirm.Presenter.Models.BlogViewModels {
	public class ArticlePreviewModel {
		public int Id { get; set; }

		public string Title { get; set; }

		public string Text { get; set; }

		public string ImagePath { get; set; }

		public DateTime CreationTime { get; set; }
		
		public int Likes { get; set; }

		public int Comments { get; set; }
	}
}