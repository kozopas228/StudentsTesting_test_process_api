using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test_Process_Services.Interfaces;
using Test_Process_Services.Models;
using Microsoft.Extensions.Configuration;

namespace Test_Process_Services.Implementation
{
    public class HttpService : IHttpService
    {
        private HttpClient _httpClient;
        private string _apiEndpoint;
        public HttpService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiEndpoint = configuration["ApiEndpoint"];
        }

        public async Task<ICollection<Answer>> GetAllAnswersAsync()
        {
            var stringResult = await _httpClient.GetStringAsync(_apiEndpoint + "/Answer");

            var deserializedResult = JsonConvert.DeserializeObject<ICollection<Answer>>(stringResult);

            return deserializedResult;
        }

        public async Task<ICollection<Question>> GetAllQuestionsAsync()
        {
            var stringResult = await _httpClient.GetStringAsync(_apiEndpoint + "/Question");

            var deserializedResult = JsonConvert.DeserializeObject<ICollection<Question>>(stringResult);

            return deserializedResult;
        }

        public async Task<ICollection<Test>> GetAllTestsAsync()
        {
            var stringResult = await _httpClient.GetStringAsync(_apiEndpoint + "/Test");

            var deserializedResult = JsonConvert.DeserializeObject<ICollection<Test>>(stringResult);

            return deserializedResult;
        }

        public async Task<Answer> GetAnswerByIdAsync(Guid id)
        {
            var stringResult = await _httpClient.GetStringAsync(_apiEndpoint + "/Answer/" + id);

            var deserializedResult = JsonConvert.DeserializeObject<Answer>(stringResult);

            return deserializedResult;
        }

        public async Task<Question> GetQuestionByIdAsync(Guid id)
        {
            var stringResult = await _httpClient.GetStringAsync(_apiEndpoint + "/Question/" + id);

            var deserializedResult = JsonConvert.DeserializeObject<Question>(stringResult);

            return deserializedResult;
        }

        public async Task<Test> GetTestByIdAsync(Guid id)
        {
            var stringResult = await _httpClient.GetStringAsync(_apiEndpoint + "/Test/" + id);

            var deserializedResult = JsonConvert.DeserializeObject<Test>(stringResult);

            return deserializedResult;
        }
    }
}