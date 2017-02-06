using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirm.Presenter.Models {
	public class LikeViewModel {
		public int Id { get; set; }

		public int IdUser { get; set; }

		public int IdType { get; set; }

		public int IdArticle { get; set; }
	}
}