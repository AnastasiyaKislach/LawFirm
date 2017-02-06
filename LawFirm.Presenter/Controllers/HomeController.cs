using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LawFirm.Presenter.Config;
using LawFirm.Presenter.Models;
using LawFirm.Presenter.Models.BlogViewModels;
using LawFirm.Presenter.Models.PracticeViewModels;
using LawFirm.Presenter.Models.TestimonialViewModels;

namespace LawFirm.Presenter.Controllers {
	public class HomeController : BaseController {
		public HomeController() { }
		public ActionResult Index() {

			HomeViewModel vm = new HomeViewModel {
				Slides = getSlides().AsQueryable(),
				PracticePreview = getPracticePreview(),
				TestimonialsPreview = getTestimonialsPreview(),
				BlogPreview = getBlogPreview(),
				RequestaConsultationForm = getRequestaConsultationPreview()
			};
			//ViewBag.AppSettings = AppSettings;
			return View(vm);
		}
		public ActionResult About() {
			return View();
		}

		public ActionResult Contacts() {
			return View();
		}

		IEnumerable<SliderViewModel> getSlides(int count = 3) {
			for (int i = 1; i <= count; i++) {
				yield return new SliderViewModel { ImagePath = String.Format("{0}/Slider/{1}.jpg", AppConfig.ImagesRootPath, i) };
			}
		}
		
		PracticeView getPracticePreview(int count = 6) {
			List<PracticeViewModel> practices = (List<PracticeViewModel>)getPractices();
			PracticeView vm = new PracticeView {
				Practices = practices
			};
			return vm;
		}

		TestimonialView getTestimonialsPreview(int count = 4) {
			List<TestimonialViewModel> testimonials = new List<TestimonialViewModel>();
			for (int i = 0; i < count; i++) {
				testimonials.Add(new TestimonialViewModel {
					Author = "Инесса Карпинская",
					Text = "Maecenas etos sit amet, consectetur adipis cing elit. Terminal volutpat rutrum metro amet sollicitudin interdum." +
						"Ante tellus gravida mollis tellus neque vitae elit. Mauris adipiscing mauris..."
				});
			}

			TestimonialView vm = new TestimonialView() {
				Testimonials = testimonials
			};

			return vm;
		}

		BlogView getBlogPreview(int count = 4) {
			List<ArticleViewModel> articles = new List<ArticleViewModel>();
			for (int i = 0; i < count; i++) {
				articles.Add(new ArticleViewModel {
					Title = "Дело Баскервилей",
					Text = "Maecenas etos sit amet, consectetur adipis cing elit. Terminal volutpat rutrum metro amet sollicitudin interdum." +
						"Ante tellus gravida mollis tellus neque vitae elit. Mauris adipiscing mauris...",
					CreationTime = new DateTime(2016, 9, 15),
					ImagePath = String.Format("{0}/Blog/{1}.jpg", AppConfig.ImagesRootPath, "Blog-photos")
					//Comments = 6,
					//Likes = 
				});
			}

			BlogView vm = new BlogView {
				Articles = articles
			};

			return vm;
		}

		private ConsultationPreviewViewModel getRequestaConsultationPreview() {
			return new ConsultationPreviewViewModel {
				PracticeAreas = getPractices().Select(ToSelectListItem).ToList()
			};
		}

		private IEnumerable<PracticeViewModel> getPractices(int count = 6) {
			List<PracticeViewModel> practices = new List<PracticeViewModel>();
			for (int i = 0; i < count; i++) {
				practices.Add(new PracticeViewModel {
					Id = i + 1,
					Title = "Bank And Financial",
					Text = "",
					ImagePath = String.Format("{0}/PracticeArea/{1}.jpg", AppConfig.ImagesRootPath, "family-sitting")
				});
			}
			return practices;
		}
		private SelectListItem ToSelectListItem(PracticeViewModel vm) {
			SelectListItem item = new SelectListItem() {
				Value = vm.Id.ToString(),
				Text = vm.Title
			};

			return item;
		}
	}
}