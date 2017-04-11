using LawFirm.Models.Entities;
using System;
using System.Linq;

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

		public Question Add(Question question) {
			if (question == null) {
				throw new ArgumentNullException(nameof(question));
			}

			question.QuestionText = question.QuestionText.Trim();
			question.Answer = question.Answer.Trim();

			Question newQuestion = DataContext.Questions.Create(question);
			DataContext.Save();

			return newQuestion;
		}

		public Question Update(Question question)
		{
			if (question == null) {
				throw new ArgumentNullException(nameof(question));
			}

			Question updateQuestion = DataContext.Questions.Update(question);
			DataContext.Save();

			return updateQuestion;

		}

		public Question Delete(int id) {
			Question question = DataContext.Questions.GetById(id);

			if (question != null) {
				question.IsDeleted = true;
			}

			Question deletedquestion = DataContext.Questions.Update(question);
			DataContext.Save();

			return deletedquestion;
		}

	}
}