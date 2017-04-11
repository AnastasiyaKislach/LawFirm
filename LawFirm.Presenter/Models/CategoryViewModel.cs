using System.Collections.Generic;
using LawFirm.Presenter.Models.BlogViewModels;

namespace LawFirm.Presenter.Models {
	public class CategoryViewModel {
		public int Id { get; set; }

		public string Title { get; set; }

		public int Articles { get; set; }
	}
}