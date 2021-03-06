using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Process_Services.Interfaces;

namespace Test_Process_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestProcessController : ControllerBase
    {
        private readonly IQuestionMixerService _questionMixerService;
        private readonly ICheckingAnswerService _checkingAnswerService;

        public TestProcessController(IQuestionMixerService questionMixerService, ICheckingAnswerService checkingAnswerService)
        {
            _questionMixerService = questionMixerService;
            _checkingAnswerService = checkingAnswerService;
        }

        [HttpPost("CheckAnswer")]
        public async Task<IActionResult> CheckAnswer(Guid testId, Guid questionId, Guid[] answersId)
        {
            return new JsonResult(await _checkingAnswerService.Check(testId, questionId, answersId));
        }

        [HttpGet("MixQuestions")]
        public async Task<IActionResult> MixQuestions(Guid testId)
        {
            return new JsonResult(await _questionMixerService.MixQuestionsAsync(testId));
        }
    }
}
