using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using LawFirm.Presenter.Models;

namespace LawFirm.Presenter.Controllers {
	public class HomeController : BaseController {
		public HomeController() { }
		public ActionResult Index() {


			HomeViewModel vm = new HomeViewModel {
				Slides = getSlides().AsQueryable(),
				CallMeBlock = getCallMeBlock(),
				PracticePreview = getPracticePreview(),
				TestimonialsPreview = getTestimonialsPreview(),
				BlogPreview = getBlogPreview(),
				RequestaConsultationForm = getRequestaConsultationPreview()
			};

			return View(vm);
		}
		public ActionResult About() {
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact() {
			ViewBag.Message = "Your contact page.";

			return View();
		}

		IEnumerable<SliderViewModel> getSlides(int count = 3) {
			for (int i = 1; i <= count; i++) {
				yield return new SliderViewModel { ImagePath = String.Format("{0}/Slider/{1}.jpg", Config.ImagesRootPath, i) };
			}
		}
		CallMeBlockViewModel getCallMeBlock() {
			return new CallMeBlockViewModel {
				Question = "У Вас есть проблемы и Вам не с кем проконсультироваться?",
				Answer = "Обратитесь ко мне! Я обещаю Вам помочь! Позвоните сейчас!",
				PhoneNumber = "8-029-123-45-67"
			};
		}
		PracticePreviewViewModel getPracticePreview(int count = 6) {
			List<PracticeViewModel> practices = (List<PracticeViewModel>)getPractices();
			PracticePreviewViewModel vm = new PracticePreviewViewModel {
				Title = "Области практики",
				ButtonText = "Перейти к полному списку",
				ButtonLink = "",
				Practices = practices
			};
			return vm;
		}

		TestimonialsPreviewViewModel getTestimonialsPreview(int count = 4) {
			List<TestimonialsViewModel> testimonials = new List<TestimonialsViewModel>();
			for (int i = 0; i < count; i++) {
				testimonials.Add(new TestimonialsViewModel {
					Author = "Инесса Карпинская",
					Text = "Maecenas etos sit amet, consectetur adipis cing elit. Terminal volutpat rutrum metro amet sollicitudin interdum." +
						"Ante tellus gravida mollis tellus neque vitae elit. Mauris adipiscing mauris..."
				});
			}

			TestimonialsPreviewViewModel vm = new TestimonialsPreviewViewModel {
				Title = "Отзывы клиентов",
				ButtonText = "Перейти к полному списку",
				ButtonLink = "",
				Testimonials = testimonials
			};

			return vm;
		}

		BlogPreviewViewModel getBlogPreview(int count = 4) {
			List<BlogItemViewModel> blogItems = new List<BlogItemViewModel>();
			for (int i = 0; i < count; i++) {
				blogItems.Add(new BlogItemViewModel {
					Title = "Дело Баскервилей",
					Text = "Maecenas etos sit amet, consectetur adipis cing elit. Terminal volutpat rutrum metro amet sollicitudin interdum." +
						"Ante tellus gravida mollis tellus neque vitae elit. Mauris adipiscing mauris...",
					Date = new DateTime(2016, 9, 15),
					ImagePath = String.Format("{0}/Blog/{1}.jpg", Config.ImagesRootPath, "Blog-photos"),
					Comments = 6,
					Likes = 10
				});
			}

			BlogPreviewViewModel vm = new BlogPreviewViewModel {
				Title = "Блог",
				ButtonText = "Перейти к полному списку",
				ButtonLink = "",
				BlogItems = blogItems
			};

			return vm;
		}

		private ConsultationPreviewViewModel getRequestaConsultationPreview() {
			return new ConsultationPreviewViewModel {
				Title = "Запись на консультацию",
				SubTitle = "Заполните форму ниже для получения консультации",
				ButtonText = "Отправить",
				PhDescription = "Описание проблемы",
				PhEmail = "Электронная почта",
				PhName = "ФИО",
				PhPhone = "Контактный телефон",
				PhAreasOfPractice = "Область права",
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
					ImagePath = String.Format("{0}/PracticeArea/{1}.jpg", Config.ImagesRootPath, "family-sitting")
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