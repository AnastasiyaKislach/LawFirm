using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawFirm.Presenter.Models {
	public class ContactsViewModel {

		[StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
		[Display(Name = "Телефон 1")]
		public string PhoneNumber1 { get; set; }

		[StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
		[Display(Name = "Телефон 2")]
		public string PhoneNumber2 { get; set; }

		[StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
		[Display(Name = "Телефон 3")]
		public string PhoneNumber3 { get; set; }

		[StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 2)]
		[Display(Name = "Город")]
		public string City { get; set; }

		[StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 2)]
		[Display(Name = "Адрес")]
		public string Address { get; set; }

		[StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 2)]
		[Display(Name = "Адрес электронной почты")]
		public string Email { get; set; }

		[StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 2)]
		[Display(Name = "Время работы 1")]
		public string WorkingHours1 { get; set; }

		
		[Display(Name = "Время работы 2")]
		public string WorkingHours2 { get; set; }

		[StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {0} символов.", MinimumLength = 2)]
		[Display(Name = "Время работы 3")]
		public string WorkingHours3 { get; set; }
	}
}