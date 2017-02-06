using System.Linq;
using LawFirm.Presenter.Models.PracticeViewModels;
using LawFirm.Presenter.Models.TestimonialViewModels;

namespace LawFirm.Presenter.Models {
	public class HomeViewModel {
		public IQueryable<SliderViewModel> Slides { get; set; }
		public PracticeView PracticePreview { get; set; }
		public TestimonialView  TestimonialsPreview { get; set; }
		public BlogView BlogPreview { get; set; }
		public ConsultationPreviewViewModel RequestaConsultationForm { get; set; }
	}
}