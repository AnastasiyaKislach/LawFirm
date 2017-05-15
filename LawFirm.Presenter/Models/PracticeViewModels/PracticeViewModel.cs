using System.Web.Mvc;

namespace LawFirm.Presenter.Models.PracticeViewModels {
	public class PracticeViewModel {
		public int Id { get; set; }
		public string Title { get; set; }

		[AllowHtml]
		public string Text { get; set; }
		public string ImagePath { get; set; }
	}
}