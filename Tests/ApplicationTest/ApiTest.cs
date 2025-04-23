using Business.Model;
using Business.Validation;
using Core.Data;
using NUnit.Framework;
using Serilog;

namespace Tests.ApplicationTest
{
    /// <summary>
    /// Test class for Api testing
    /// </summary>
    [Category("API")]
    [Parallelizable]
    internal class ApiTest : Test
    {
        //Validate that the list of users can be received successfully
        [Test]
        public async Task GetUser()
        {
            Log.Information("Executing GET request for User at {Endpoint}", ConfigProvider.ApiUrl + ConfigProvider.Users);

            var response = await Rest!.GetAsync<User>();

            Log.Information("GET request completed");

            ApiValidation.ValidateUser(response);
            ApiValidation.ValidateOkResponse(response);
        }

        //Validate response header for a list of users 
        [Test]
        public async Task UsersHeaders()
        {
            Log.Information("Executing GET request for User at {Endpoint}", ConfigProvider.ApiUrl + ConfigProvider.Users);

            var response = await Rest!.GetAsync<User>();

            Log.Information("GET request completed");

            ApiValidation.ValidateContentTypeHeader(response);
            ApiValidation.ValidateOkResponse(response);
        }

        //Validate response header for a list of users 
        [Test]
        public async Task GetUsers()
        {
            Log.Information("Executing GET request for User at {Endpoint}", ConfigProvider.ApiUrl + ConfigProvider.Users);

            var response = await Rest!.GetAsync<User>();

            Log.Information("GET request completed");

            ApiValidation.ValidateTenUsers(response);
            ApiValidation.ValidateUserDistinct(response);
            ApiValidation.ValidateUsersNameAndUsername(response);
            ApiValidation.ValidateUsersCompanyName(response);
            ApiValidation.ValidateOkResponse(response);
        }

        //Validate that user can be created
        [Test]
        public async Task UserCreated()
        {
            var user = new User
            {
                Name = "John",
                Username = "Doe"
            };

            Log.Information("Executing Post request for User at {Endpoint}", ConfigProvider.ApiUrl + ConfigProvider.Users);

            var response = await Rest!.CreateAsync<User>(user);

            Log.Information("Post request completed");

            ApiValidation.ValidateResponseNotEmpty(response);
            ApiValidation.ValidateResponseContainsId(response);
            ApiValidation.ValidateOkResponse(response);
        }

        //Validate that user is notified if resource doesn’t exist
        [Test]
        public async Task NotFound()
        {
            Log.Information("Executing GET request for invalid end point at {Endpoint}", ConfigProvider.ApiUrl + ConfigProvider.Invalid);

            var response = await Rest!.GetAsync();

            Log.Information("Get request completed");

            ApiValidation.ValidateNotFoundResponse(response);
        }
    }
}
