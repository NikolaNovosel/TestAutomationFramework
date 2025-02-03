using Business.Model;
using FluentAssertions;
using RestSharp;
using System.Net;

namespace Business.Validation
{
    public static class ApiValidation
    {
        public static void ValidateOkResponse(RestResponse<List<User>> response)
        {
            // Validate the response status code to ensure it's successful
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate that there are no error messages in the response
            response.ErrorMessage.Should().BeNullOrEmpty();
        }
        public static void ValidateOkResponse(RestResponse<User> response)
        {
            // Validate the response status code to ensure it's successful
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate that there are no error messages in the response
            response.ErrorMessage.Should().BeNullOrEmpty();
        }

        public static void ValidateUser(RestResponse<List<User>> response)
        {
            // Validate each user in the response data
            foreach (var user in response.Data!)
            {
                user.Id.Should().BeGreaterThan(0);
                user.Name.Should().NotBeNullOrWhiteSpace();
                user.Username.Should().NotBeNullOrWhiteSpace();
                user.Email.Should().NotBeNullOrWhiteSpace();
                user.Address.Should().NotBeNull();
                user.Phone.Should().NotBeNullOrWhiteSpace();
                user.Website.Should().NotBeNullOrWhiteSpace();
                user.Company.Should().NotBeNull();
            }
        }

        public static void ValidateContentTypeHeader(RestResponse<List<User>> response)
        {
            // Validate that the Content-Type header has the exact value
            response.ContentType.Should().Be("application/json");
        }

        public static void ValidateTenUsers(RestResponse<List<User>> response)
        {
            response.Data.Should().HaveCount(10);
        }

        public static void ValidateUserDistinct(RestResponse<List<User>> response)
        {
            response.Data!.Select(user => user.Id).Should().OnlyHaveUniqueItems();
        }

        public static void ValidateUsersNameAndUsername(RestResponse<List<User>> response)
        {
            response.Data.Should().AllSatisfy(user =>
            {
                user.Name.Should().NotBeNullOrWhiteSpace();
                user.Username.Should().NotBeNullOrWhiteSpace();
            });
        }

        public static void ValidateUsersCompanyName(RestResponse<List<User>> response)
        {
            response.Data.Should().AllSatisfy(user =>
            {
                user.Company!.Name.Should().NotBeNullOrWhiteSpace();
            });
        }

        public static void ValidateResponseNotEmpty(RestResponse<User> response)
        {
            // Validate that the response is not empty
            response.Content.Should().NotBeNullOrEmpty();
        }

        public static void ValidateResponseContainsId(RestResponse<User> response)
        {
            // Validate response contains the Id value
            response.Data!.Id.Should().BeGreaterThan(0);
        }

        public static void ValidateNotFoundResponse(RestResponse response)
        {
            // Validate the response status code is 201 Created
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            // Validate there are no error messages
            response.ErrorMessage.Should().BeNullOrEmpty();
        }
    }
}
