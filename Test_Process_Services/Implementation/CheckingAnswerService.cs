using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Process_Services.Interfaces;
using Test_Process_Services.Models;

namespace Test_Process_Services.Implementation
{
    public class CheckingAnswerService : ICheckingAnswerService
    {
        private readonly IHttpService _httpService;

        public CheckingAnswerService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<CheckResultModel> Check(Guid testId, Guid questionId, ICollection<Guid> answersId)
        {
            var test = await _httpService.GetTestByIdAsync(testId);

            if (test.QuestionsIds.Contains(questionId) == false)
            {
                throw new ArgumentException();
            }

            var question = await _httpService.GetQuestionByIdAsync(questionId);

            foreach (var id in question.AnswersIds)
            {
                if (question.AnswersIds.Contains(id) == false)
                {
                    throw new ArgumentException();
                }
            }

            var requestedAnswers = new List<Answer>();

            foreach (var id in answersId)
            {
                requestedAnswers.Add(await _httpService.GetAnswerByIdAsync(id));
            }

            bool result = requestedAnswers.Count == question.AnswersIds.Count;

            foreach (var b in requestedAnswers)
            {
                if (b.IsCorrect == false)
                {
                    result = false;
                    break;
                }
            }

            var answers = new List<Answer>();

            foreach (var id in question.AnswersIds)
            {
                var res = await _httpService.GetAnswerByIdAsync((Guid) id);

                answers.Add(res);
            }

            return new CheckResultModel
            {
                Correct = result, 
                CorrectAnswers = answers
                    .Where(x => x.IsCorrect)
                    .ToList()
            };
        }
    }
}