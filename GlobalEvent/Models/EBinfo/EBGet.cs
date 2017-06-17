using System.Net.Http;
using System.Threading.Tasks;

namespace GlobalEvent.Models.EBinfo
{
    public class EBGet
	{
		public string responseE { get; set;}

        public EBGet()
        {
            SendRequest().Wait();
        }
        
        private async Task SendRequest()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync("https://www.eventbriteapi.com/v3/events/35326692087/attendees/?token=WA2XSMPXNXSTNV7H3YRD");
                    response.EnsureSuccessStatusCode(); // Throw if not success

                    responseE = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    responseE = ($"Request exception: {e.Message}");
                }
            }
        }
	}
}