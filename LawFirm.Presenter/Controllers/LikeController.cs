using System.Web.Mvc;
using LawFirm.BusinessLogic;
using LawFirm.Models;
using LawFirm.Presenter.Config;
using LawFirm.Presenter.Models.BlogViewModels;
using Microsoft.AspNet.Identity;

namespace LawFirm.Presenter.Controllers {
	public class LikeController : BaseController {
		protected LikeService LikeService { get; set; }

		public LikeController() {
			LikeService = new LikeService(AppConfig.ConnectionString);
		}

		[Authorize]
		public ActionResult LikingArticle(int id) {

			string userId = User.Identity.GetUserId();

			LikeResult likeResult = LikeService.LikeArticle(userId, id);

			LikeViewModel vm = ToViewModel(likeResult);

			return PartialView("_LikingResult", vm);
		}

		public ActionResult LikingComment(int id) {

			var userId = User.Identity.GetUserId();

			LikeResult likeResult = LikeService.LikeComment(userId, id);

			LikeViewModel vm = ToViewModel(likeResult);

			return PartialView("_LikingResultComment", vm);
		}

		protected LikeViewModel ToViewModel(LikeResult model) {
			LikeViewModel vm = new LikeViewModel() {
				Count = model.Count,
				IsLiked = model.IsLiked,
				PublicationId = model.PublicationId
			};

			return vm;
		}
	}
}