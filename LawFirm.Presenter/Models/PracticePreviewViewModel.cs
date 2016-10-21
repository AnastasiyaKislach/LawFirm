using System.Collections.Generic;

namespace LawFirm.Presenter.Models {
	public class PracticePreviewViewModel {
		public string Title { get; set; }
		public string ButtonText { get; set; }
		public string ButtonLink { get; set; }
		public IEnumerable<PracticeViewModel> Practices { get; set; }
	}
}