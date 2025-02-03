using Core.Data;
using RestSharp;

namespace Core.Api
{
    public class UserClient
    {
        private readonly RestClient _client = new(ConfigProvider.Api!);

        // Send the request and get the response
        public async Task<RestResponse<List<T>>> GetUsersAsync<T>()
        {
            var request = new RestRequest("users", Method.Get);

            var response = await _client.ExecuteAsync<List<T>>(request);

            return response;
        }
        // Create the request object
        public async Task<RestResponse<T>> CreateUserAsync<T>(T user) where T:class
        {
            var request = new RestRequest("users", Method.Post);

            request.AddJsonBody(user);

            var response = await _client.ExecuteAsync<T>(request);

            return response;
        }
        // Create the request object for the invalid endpoint
        public async Task<RestResponse> GetInvalidEndpointAsync()
        {
            var request = new RestRequest("invalidendpoint", Method.Get);

            var response = await _client.ExecuteAsync(request);

            return response;
        }
    }
}
