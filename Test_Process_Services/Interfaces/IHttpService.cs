using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test_Process_Services.Models;

namespace Test_Process_Services.Interfaces
{
    public interface IHttpService
    {
        Task<ICollection<Answer>> GetAllAnswersAsync();
        Task<ICollection<Question>> GetAllQuestionsAsync();
        Task<ICollection<Test>> GetAllTestsAsync();
        Task<Answer> GetAnswerByIdAsync(Guid id);
        Task<Question> GetQuestionByIdAsync(Guid id);
        Task<Test> GetTestByIdAsync(Guid id);
    }
}