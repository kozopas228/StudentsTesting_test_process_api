using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Process_API.ViewModels
{
    public class CheckAnswerViewModel
    {
        public Guid testId { get; set; }
        public Guid questionId { get; set; } 
        public Guid[] answersId { get; set; }
    }
}
