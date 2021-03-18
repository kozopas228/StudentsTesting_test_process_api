using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Process_API.ViewModels;
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
        public async Task<IActionResult> CheckAnswer([FromBody] CheckAnswerViewModel model)
        {
            return new JsonResult(await _checkingAnswerService.Check(model.testId, model.questionId, model.answersId));
        }

        [HttpGet("MixQuestions")]
        public async Task<IActionResult> MixQuestions(Guid testId)
        {
            return new JsonResult(await _questionMixerService.MixQuestionsAsync(testId));
        }

        [HttpGet("Test")]
        public IActionResult Test(Guid testId)
        {
            return Ok("congrats!");
        }

        [HttpPatch("TestPatch")]
        public IActionResult TestPatch()
        {
            return Ok();
        }
        [HttpPut("TestPut")]
        public IActionResult TestPut()
        {
            return Ok();
        }

    }
}
