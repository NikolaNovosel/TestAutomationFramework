using RestSharp;

namespace Core.Api
{
    // <summary>
    // Fluent builder for configuring RestSharp requests with method chaining
    // </summary>
    internal class RequestBuilder : IRequestBuilder
    {
        // Internal RestRequest instance for building the request
        private readonly RestRequest _request = new();

        // Adds a JSON body to the request
        public IRequestBuilder AddJsonBody<T>(T user) where T : class 
        { 
            _request.AddJsonBody(user);
            return this; 
        }

        // Sets the HTTP method for the request
        public IRequestBuilder Method(Method method)
        {
            _request.Method = method; 
            return this;
        }

        // Sets the resource (endpoint) for the request
        public IRequestBuilder Resource(string resource) 
        { 
            _request.Resource = resource;
            return this;
        }

        // Returns the configured RestRequest
        public RestRequest GetRequest() => _request;
    }
}
