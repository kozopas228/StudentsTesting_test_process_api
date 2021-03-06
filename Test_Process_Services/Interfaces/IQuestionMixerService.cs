using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test_Process_Services.Models;

namespace Test_Process_Services.Interfaces
{
    public interface IQuestionMixerService
    {
        Task<ICollection<Question>> MixQuestionsAsync(Guid testId);
    }
}