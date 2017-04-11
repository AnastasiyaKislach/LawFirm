using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirm.Presenter.Models {
	public class BlogItemViewModel {
		public string Title { get; set; }
		public string Text { get; set; }
		public string ImagePath { get; set; }
		public DateTime Date { get; set; }
		public int Likes { get; set; } //коллекция?
		public int Comments { get; set; }
	}
}