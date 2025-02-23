using Core.Data;
using Serilog;
using RestSharp;

namespace Core.Api
{
    // <summary>
    // Manages REST API interactions using RestSharp client
    // </summary>
    public class Rest
    {
        // RestClient configured with base API URL from configuration
        private readonly RestClient _client = new(ConfigProvider.ApiUrl!);

        // Send the get request for the type and get the response for the type
        public async Task<RestResponse<List<T>>> GetAsync<T>()
        {
            Log.Information("Send the get request for the type");
            var request = new RequestDirector().GetUsersRequest();

            Log.Information("Get the response from the type");
            return await _client.ExecuteAsync<List<T>>(request);
        }

        // Send the get request for the invalid end point and get the response for the invalid endpoint
        public async Task<RestResponse> GetAsync()
        {
            Log.Information("Send the get request for the invalid end point");
            var request = new RequestDirector().GetInvalidRequest();

            Log.Information("Get the response from the invalid end point");
            return await _client.ExecuteAsync(request);
        }

        // Send the post request object and get the response for the created object
        public async Task<RestResponse<T>> CreateAsync<T>(T user) where T : class
        {
            Log.Information("Send the post request object");
            var request = new RequestDirector().PostUsersRequest(user);

            Log.Information("Get the response for the created object");
            return await _client.ExecuteAsync<T>(request);
        }
    }
}
