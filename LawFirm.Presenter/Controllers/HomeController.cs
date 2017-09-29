using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LawFirm.Presenter.Config;
using LawFirm.Presenter.Models;
using LawFirm.Presenter.Models.BlogViewModels;
using LawFirm.Presenter.Models.PracticeViewModels;
using LawFirm.Presenter.Models.TestimonialViewModels;
using LawFirm.BusinessLogic;

namespace LawFirm.Presenter.Controllers {
	public class HomeController : BaseController {
		public HomeController() { }
		public ActionResult Index() {

			HomeViewModel vm = new HomeViewModel {
				Slides = getSlides().AsQueryable(),
				PracticePreview = getPracticePreview(),
				TestimonialsPreview = getTestimonialsPreview(),
				ArticlesPreview = getBlogPreview().AsQueryable(),
				RequestaConsultationForm = getRequestaConsultationPreview()
			};

			return View(vm);
		}
		public ActionResult About() {
			return View();
		}

		public ActionResult Contacts() {
			return View();
		}

		public ActionResult Administrate() {
			return View();
		}

		IEnumerable<SlideViewModel> getSlides(int count = 3) {

			List<SlideViewModel> slides = new List<SlideViewModel>();

			SlideService service = new SlideService(AppConfig.ConnectionString);

			slides = service.GetAll().Take(count).Select(i => new SlideViewModel() {
				Id = i.Id,
				ImagePath = AppConfig.ImagesRootPath + "/Slider/" + i.ImagePath
			}).ToList();

			for (int i = 0; i < count; i++) {
				yield return slides[i];
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

			TestimonialService service = new TestimonialService(AppConfig.ConnectionString);

			testimonials = service.GetAllApproved().Take(count).Select(i => new TestimonialViewModel() {
				Author = i.Author,
				Text = i.Text
			}).ToList();

			TestimonialView vm = new TestimonialView() {
				Testimonials = testimonials
			};

			return vm;
		}

		List<ArticlePreviewModel> getBlogPreview(int count = 4) {
			List<ArticlePreviewModel> articles = new List<ArticlePreviewModel>();

			ArticleService service = new ArticleService(AppConfig.ConnectionString);

			var articlesQuery = service.GetAll().OrderByDescending(i => i.CreationTime).Take(count);

			articles = articlesQuery.Select(
				i => new ArticlePreviewModel() {
					Id = i.Id,
					ImagePath = AppConfig.BlogImagesPath + i.ImagePath,
					Title = i.Title,
					Text = i.Text != "" ? (i.Text.Length > 50 ? i.Text.Substring(0, 50) : "") : "",
					CreationTime = i.CreationTime,
					Comments = i.Comments.Count,
					Likes = i.Likes.Count
				}).ToList();

			LikeService likeService = new LikeService(AppConfig.ConnectionString);


			//for (int i = 0; i < articles.Count; i++) {
			//	articles[i].Likes = likeService.GetAll(articles[i].Id, (int)LawFirm.Models.Entities.PublicationType.Article).ToList().Count;
			//}

			return articles;
		}

		private ConsultationPreviewModel getRequestaConsultationPreview() {
			return new ConsultationPreviewModel {
				Practices = getPractices().Select(ToSelectListItem)
			};
		}

		private IEnumerable<PracticeViewModel> getPractices(int count = 6) {
			List<PracticeViewModel> practices = new List<PracticeViewModel>();

			PracticeService service = new PracticeService(AppConfig.ConnectionString);

			practices = service.GetAll().Take(count).Select(i => new PracticeViewModel() {
				Id = i.Id,
				ImagePath = AppConfig.PracticeImagesPath + i.ImagePath,
				Title = i.Title,
				Text = i.Text
			}).ToList();

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