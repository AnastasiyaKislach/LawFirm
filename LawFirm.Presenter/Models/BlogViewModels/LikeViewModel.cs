using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirm.Presenter.Models.BlogViewModels {
	public class LikeViewModel {
		public int Count { get; set; }

		public bool IsLiked{ get; set; }

		public int PublicationId { get; set; }
	}
}