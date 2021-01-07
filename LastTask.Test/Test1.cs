using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using LastTask;

namespace LastTask.Test
{
    public class Test1
	{

		protected readonly HttpClient _client;


		public Test1()
		{
			var server = new TestServer(new WebHostBuilder()
				.UseEnvironment("Development")
				.UseStartup<Startup>());

			_client = server.CreateClient();
		}

		[Fact]
		public async Task TestHealthCheck()
		{
			var response = await _client.GetAsync("health");
			response.EnsureSuccessStatusCode();

			Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

			var responseString = await response.Content.ReadAsStringAsync();

			Assert.Equal("Healthy", responseString);
		}

	}
}
