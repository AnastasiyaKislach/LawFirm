using System.Linq;

namespace LawFirm.Presenter.Models {
	public class HomeViewModel {
		public IQueryable<SliderViewModel> Slides { get; set; }
		public CallMeBlockViewModel CallMeBlock { get; set; }
		public PracticePreviewViewModel PracticePreview { get; set; }
		public TestimonialsPreviewViewModel  TestimonialsPreview { get; set; }
		public BlogPreviewViewModel BlogPreview { get; set; }
		public ConsultationPreviewViewModel RequestaConsultationForm { get; set; }
	}
}