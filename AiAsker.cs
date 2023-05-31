using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KeywordExtraction
{
    public class AiAsker
    {
        /// <summary>
        /// httpclient
        /// </summary>
        public HttpClient HttpClient { get;  set; }
        public  string Uri { get; set; }

        /// <summary>
        /// comstructor
        /// </summary>
        /// <param name="uriString"></param>
        public AiAsker(string uriString)
        {
            HttpClient = new HttpClient();
            Uri = uriString;
        }

        /// <summary>
        /// 透過HTTP請求的方式，串接目前的自訂報表服務
        /// </summary>
        /// <param name="reportRequest"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<string> GetAiResponse(AskAiRequest askAiRequest)
        {
            string requestMessage = JsonConvert.SerializeObject(askAiRequest, Formatting.Indented);

            var content = new StringContent(requestMessage, Encoding.UTF8, "application/json");

            //HttpClient.DefaultRequestHeaders.Add("accept", "text/plain");
            //HttpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");


            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Uri);
            request.Headers.Add("Accept", "text/plain");
            request.Content = new StringContent(requestMessage, System.Text.Encoding.UTF8,"application/json");



            HttpResponseMessage respondResult = await HttpClient.SendAsync(request);
            respondResult.EnsureSuccessStatusCode();

            string respondResultString = await respondResult.Content.ReadAsStringAsync();

            //AskAiResponse respond = JsonConvert.DeserializeObject<AskAiResponse>(respondResultString);

            return respondResultString;
        }

    }
}
