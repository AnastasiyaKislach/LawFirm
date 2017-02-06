using LawFirm.DataAccess;
using LawFirm.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.BusinessLogic {
	public class QuestionService : BaseService {
		public QuestionService(string connectionString) : base(connectionString) {
		}

		public IQueryable<Question> GetAll() {
			return DataContext.Questions.GetAll().Where(i => !i.IsDeleted);
		}

		public Question GetById(int id) {
			Question question = DataContext.Questions.GetById(id);
			return question;
		}


		public void Add(Question question) {
			if (question == null) {
				throw new ArgumentNullException(nameof(question));
			}

			question.QuestionText = question.QuestionText.Trim();
			question.Answer = question.Answer.Trim();

			DataContext.Questions.Create(question);
			DataContext.Save();
		}

		public void Delete(int id) {
			Question question = DataContext.Questions.GetById(id);

			if (question != null) {
				question.IsDeleted = true;
			}

			DataContext.Questions.Update(question);
			DataContext.Save();
		}
		
	}
}