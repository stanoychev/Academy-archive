using Sensei.Services;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sensei.Tests.Tools.CustomMockClasses
{
    public class SensorApiServiceMock : SensorApiService
    {
        private readonly string jsonString;

        public SensorApiServiceMock(HttpClient httpClient, string jsonString) : base(httpClient)
        {
            this.jsonString = jsonString;
        }

        protected override Task<string> GetJson(string url)
        {
            return Task.FromResult(this.jsonString);
        }
    }
}
