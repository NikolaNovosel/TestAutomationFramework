using Core.Data;
using RestSharp;

namespace Core.Api
{
    // <summary>
    // Director class for creating predefined RestSharp request configurations
    // </summary>
    internal class RequestDirector
    {
        // RequestBuilder instance for creating requests
        private readonly IRequestBuilder _restBuilder = new RequestBuilder();

        // Creates a GET request for retrieving user
        public RestRequest GetUsersRequest() => _restBuilder.Method(Method.Get).Resource(ConfigProvider.Users!).GetRequest();

        // Creates a GET request for an invalid endpoint
        public RestRequest GetInvalidRequest() => _restBuilder.Method(Method.Get).Resource(ConfigProvider.Invalid!).GetRequest();

        // Creates a POST request for adding a new user
        public RestRequest PostUsersRequest<T>(T user) where T : class 

            => _restBuilder.Method(Method.Post).Resource(ConfigProvider.Users!).AddJsonBody(user).GetRequest();
    }
}
