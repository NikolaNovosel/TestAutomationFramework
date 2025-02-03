using Business.Model;
using Business.Validation;
using NUnit.Framework;

namespace Tests.ApplicationTest
{
    //[TestFixture]
    //[Parallelizable(ParallelScope.Children)]
    internal class ApiTest : Test
    {
        //Tasks #1. Validate that the list of users can be received successfully
        [Test]
        public async Task Task1()
        {
            var response = await UserClient!.GetUsersAsync<User>();

            ApiValidation.ValidateUser(response);
            ApiValidation.ValidateOkResponse(response);
        }

        //Tasks #2. Validate response header for a list of users 
        [Test]
        public async Task Task2()
        {
            var response = await UserClient!.GetUsersAsync<User>();

            ApiValidation.ValidateContentTypeHeader(response);
            ApiValidation.ValidateOkResponse(response);
        }

        //Tasks #3. Validate response header for a list of users 
        [Test]
        public async Task Task3()
        {
            var response = await UserClient!.GetUsersAsync<User>();

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

            var response = await UserClient!.CreateUserAsync<User>(user);

            ApiValidation.ValidateResponseNotEmpty(response);
            ApiValidation.ValidateResponseContainsId(response);
            ApiValidation.ValidateOkResponse(response);
        }

        //Tasks #5. Validate that user is notified if resource doesn’t exist
        [Test]
        public async Task Task5()
        {
            var response = await UserClient!.GetInvalidEndpointAsync();

            ApiValidation.ValidateNotFoundResponse(response);
        }
    }
}
