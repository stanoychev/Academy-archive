//using Sensei.Services;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace Sensei.Tests.Tools.CustomMockClasses
//{
//    public class APIServiceMock : APIService
//    {
//        private readonly string jsonString;

//        public APIServiceMock(HttpClient httpClient, string jsonString) : base(httpClient)
//        {
//            this.jsonString = jsonString;
//        }

//        protected override Task<string> GetJson(string url)
//        {
//            return Task.FromResult(this.jsonString);
//        }
//    }
//}
