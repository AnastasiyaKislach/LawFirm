using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirm.Presenter.Models {
	public class LikeViewModel {
		public int Id { get; set; }

		public int ApplicationUserId { get; set; }

		public int TypeId { get; set; }

		public int ArticleId { get; set; }
	}
}