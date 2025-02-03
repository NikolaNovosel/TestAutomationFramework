using RestSharp;

namespace Core.Api
{
    // <summary>
    // Defines a builder for constructing and configuring RestSharp requests
    // </summary>
    internal interface IRequestBuilder
    {
        // Retrieves the current RestRequest configured by the builder
        RestRequest GetRequest();

        // Adds a JSON body to the request
        IRequestBuilder AddJsonBody<T>(T user) where T : class;

        // Sets the HTTP method for the request
        IRequestBuilder Method(Method method);

        // Sets the resource (endpoint) for the request
        IRequestBuilder Resource(string resource);
    }
}
