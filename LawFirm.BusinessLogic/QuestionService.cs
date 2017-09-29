using LawFirm.Models.Entities;
using System;
using System.Linq;

namespace LawFirm.BusinessLogic {
	public class QuestionService : BaseService<Question> {
		public QuestionService(string connectionString) : base(connectionString) {
		}

		public override IQueryable<Question> GetAll() {
			return base.GetAll().Where(i => !i.IsDeleted);
		}

		public Question Add(Question question) {
			if (question == null) {
				throw new ArgumentNullException(nameof(question));
			}

			question.QuestionText = question.QuestionText.Trim();
			question.Answer = question.Answer.Trim();

			Question newQuestion = Create(question);
			Save();

			return newQuestion;
		}

		public Question Edit(Question question) {
			if (question == null) {
				throw new ArgumentNullException(nameof(question));
			}

			Question updateQuestion = Update(question);
			Save();

			return updateQuestion;

		}

		public Question Delete(int id) {
			Question question = GetById(id);

			if (question != null) {
				question.IsDeleted = true;
			}

			Question deletedquestion = Update(question);
			Save();

			return deletedquestion;
		}

	}
}