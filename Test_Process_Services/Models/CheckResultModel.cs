using System.Collections;
using System.Collections.Generic;

namespace Test_Process_Services.Models
{
    public class CheckResultModel
    {
        public bool Correct { get; set; }
        public ICollection<Answer> CorrectAnswers { get; set; }
    }
}