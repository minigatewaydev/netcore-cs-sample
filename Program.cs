using System;
using MgNetcoreCsSample.Core;
using System.Threading.Tasks;
using MgNetcoreCsSample.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Web;

namespace MgNetcoreCsSample
{
    class Program
    {
        private static readonly string baseUrl = "http://162.253.16.28:5010/api/send";
        private static RestApiSender api;

        static async Task Main(string[] args)
        {
            api = new RestApiSender();

            Console.WriteLine("===============================");
            Console.WriteLine("  .NETCore MiniGateway Sample");
            Console.WriteLine("===============================");
            Console.WriteLine("To initiate, press ENTER key");
            Console.WriteLine();

            /* TODO: change according to your own data
             * for username & password. If you set 'DlrMask' to 1,
             * please specify the 'DlrUrl'
             */

            MtRequest request = new MtRequest
            {
                Username = "httppostpaid",
                Password = "123456",
                From = ".NET Sample",
                To = "60123456789",
                Text = ".NETCore (C#) sample using HTTP POST & GET",
                Coding = "1",
                DlrMask = "0",
                DlrUrl = "<YOUR-DLR-URL>",
                ResponseType = "json"
            };

            do
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    /* TODO: change this between 1 - 2 to switch result
                     * 1 = Send using POST
                     * 2 = Send using GET
                     */
                    var type = 1;
                    switch (type)
                    {
                        case 1: await SendSmsUsingPostAsync(request); break;
                        case 2: await SendSmsUsingGetAsync(request); break;
                    }
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        private async static Task SendSmsUsingPostAsync(MtRequest request)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine("Executing POST request..");

            var response = await api.SendPostRequestAsync(request, baseUrl);
            var contentStr = await response.Content.ReadAsStringAsync();

            if (request.ResponseType == "json")
            {
                // Use for future usage
                var obj = JsonConvert.DeserializeObject<MtResponse>(contentStr);
            }

            stopwatch.Stop();
            Console.WriteLine($"Finished. Time taken: {stopwatch.Elapsed}");
            Console.WriteLine($"Response = StatusCode: {response.StatusCode}, Content: {contentStr}");
            Console.WriteLine();
            Console.WriteLine("To resend, press ENTER key 2x");
            Console.WriteLine("To exit, press ESC key");
            Console.WriteLine();
        }

        private async static Task SendSmsUsingGetAsync(MtRequest request)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine("Executing GET request..");

            var url = $"{baseUrl}?" +
                $"{MtRequest.GW_USERNAME}={request.Username}&" +
                $"{MtRequest.GW_PASSWORD}={request.Password}&" +
                $"{MtRequest.GW_FROM}={HttpUtility.UrlEncode(request.From)}&" +
                $"{MtRequest.GW_TO}={HttpUtility.UrlEncode(request.To)}&" +
                $"{MtRequest.GW_TEXT}={HttpUtility.UrlEncode(request.Text)}&" +
                $"{MtRequest.GW_CODING}={request.Coding}&" +
                $"{MtRequest.GW_DLR_MASK}={request.DlrMask}&" +
                $"{MtRequest.GW_DLR_URL}={request.DlrUrl}&" +
                $"{MtRequest.GW_RESP_TYPE}={request.ResponseType}";

            var response = await api.SendGetRequestAsync(url);
            string contentStr = await response.Content.ReadAsStringAsync();

            if (request.ResponseType == "json")
            {
                // Use for future usage
                var obj = JsonConvert.DeserializeObject<MtResponse>(contentStr);
            }

            stopwatch.Stop();
            Console.WriteLine($"Finished. Time taken: {stopwatch.Elapsed}");
            Console.WriteLine($"Response = StatusCode: {response.StatusCode}, Content: {contentStr}");
            Console.WriteLine();
            Console.WriteLine("To resend, press ENTER key 2x");
            Console.WriteLine("To exit, press ESC key");
            Console.WriteLine();
        }
    }
}
