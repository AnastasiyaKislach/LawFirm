using System.Linq;
using LawFirm.Presenter.Models.PracticeViewModels;
using LawFirm.Presenter.Models.TestimonialViewModels;
using LawFirm.Presenter.Models.BlogViewModels;


namespace LawFirm.Presenter.Models {
	public class HomeViewModel {
		public IQueryable<SlideViewModel> Slides { get; set; }
		public PracticeView PracticePreview { get; set; }
		public TestimonialView  TestimonialsPreview { get; set; }
		public IQueryable<ArticlePreviewModel> ArticlesPreview { get; set; }
		public ConsultationPreviewModel RequestaConsultationForm { get; set; }
	}
}