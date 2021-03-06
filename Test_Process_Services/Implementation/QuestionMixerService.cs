using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Process_Services.Interfaces;
using Test_Process_Services.Models;

namespace Test_Process_Services.Implementation
{
    public class QuestionMixerService : IQuestionMixerService
    {
        private readonly IHttpService _service;

        public QuestionMixerService(IHttpService service)
        {
            _service = service;
        }

        public async Task<ICollection<Question>> MixQuestionsAsync(Guid testId)
        {
            var test = await _service.GetTestByIdAsync(testId);

            var questions = new List<Question>();

            foreach (var id in test.QuestionsIds)
            {
                questions.Add(await _service.GetQuestionByIdAsync((Guid)id));
            }

            RandomizeQuestions(questions);

            return questions;
        }

        private void RandomizeQuestions(List<Question> questions)
        {
            var resultList = new List<Question>();

            var rnd = new Random();

            while (true)
            {
                var number = rnd.Next(0, questions.Count);

                if (resultList.Contains(questions[number]) == false)
                {
                    resultList.Add(questions[number]);
                }

                if (resultList.Count == questions.Count)
                {
                    break;
                }
            }

            questions.Clear();

            resultList.ForEach(x=> questions.Add(x));

            resultList.ForEach(x => RandomizeAnswers(x));
        }

        private void RandomizeAnswers(Question question)
        {
            var resultList = new List<Guid?>();

            var rnd = new Random();

            while (true)
            {
                var number = rnd.Next(0, question.AnswersIds.Count);

                if (resultList.Contains(question.AnswersIds.ToList()[number]) == false)
                {
                    resultList.Add(question.AnswersIds.ToList()[number]);
                }

                if (resultList.Count == question.AnswersIds.Count)
                {
                    break;
                }
            }

            question.AnswersIds.Clear();

            resultList.ForEach(x=> question.AnswersIds.Add(x));
        }
    }
}