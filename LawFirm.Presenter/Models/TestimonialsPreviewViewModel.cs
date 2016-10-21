using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirm.Presenter.Models {
	public class TestimonialsPreviewViewModel {
		public string Title { get; set; }
		public string ButtonText { get; set; }
		public string ButtonLink { get; set; }
		public IEnumerable<TestimonialsViewModel> Testimonials { get; set; }
	}
}