using Business.Model;
using Business.Validation;
using Core.Data;
using NUnit.Framework;
using Serilog;

namespace Tests.ApplicationTest
{
    internal class ApiTest : Test
    {
        //Tasks #1. Validate that the list of users can be received successfully
        [Test]
        public async Task Task1()
        {
            Log.Information("Executing GET request for User at {Endpoint}", ConfigProvider.Api);

            var response = await Rest!.GetAsync<User>();

            Log.Information("GET request completed");

            ApiValidation.ValidateUser(response);
            ApiValidation.ValidateOkResponse(response);
        }

        //Tasks #2. Validate response header for a list of users 
        [Test]
        public async Task Task2()
        {
            Log.Information("Executing GET request for User at {Endpoint}", ConfigProvider.Api);

            var response = await Rest!.GetAsync<User>();

            Log.Information("GET request completed");


            ApiValidation.ValidateContentTypeHeader(response);
            ApiValidation.ValidateOkResponse(response);
        }

        //Tasks #3. Validate response header for a list of users 
        [Test]
        public async Task Task3()
        {
            Log.Information("Executing GET request for User at {Endpoint}", ConfigProvider.Api);

            var response = await Rest!.GetAsync<User>();

            Log.Information("GET request completed");

            ApiValidation.ValidateTenUsers(response);
            ApiValidation.ValidateUserDistinct(response);
            ApiValidation.ValidateUsersNameAndUsername(response);
            ApiValidation.ValidateUsersCompanyName(response);
            ApiValidation.ValidateOkResponse(response);
        }

        //Tasks #4. Validate that user can be created
        [Test]
        public async Task Task4()
        {
            var user = new User
            {
                Name = "John",
                Username = "Doe"
            };

            Log.Information("Executing Post request for User at {Endpoint}", ConfigProvider.Api);

            var response = await Rest!.CreateAsync<User>(user);

            Log.Information("Post request completed");

            ApiValidation.ValidateResponseNotEmpty(response);
            ApiValidation.ValidateResponseContainsId(response);
            ApiValidation.ValidateOkResponse(response);
        }

        //Tasks #5. Validate that user is notified if resource doesn’t exist
        [Test]
        public async Task Task5()
        {
            Log.Information("Executing GET request for invalid end point at {Endpoint}", ConfigProvider.Api);

            var response = await Rest!.GetAsync();

            Log.Information("Get request completed");

            ApiValidation.ValidateNotFoundResponse(response);
        }
    }
}
