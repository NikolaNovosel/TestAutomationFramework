using Business.Model;
using FluentAssertions;
using RestSharp;
using System.Net;
using Serilog;
using NUnit.Framework;

namespace Business.Validation
{
    // <summary>
    // This static class provides helper methods for validating API responses. 
    // </summary>
    public static class ApiValidation
    {
        // Validates that the response status code is OK (200) and there are no error messages
        public static void ValidateOkResponse(RestResponse<List<User>> response)
        {
            try
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                Log.Information("Successfully validate API response - Expected Status: OK, Actual: {StatusCode}", response.StatusCode);
            }
            catch (AssertionException)
            {
                Log.Error("Fail to validate API response - Expected Status: OK, Actual: {StatusCode}", response.StatusCode);

                throw;
            }

            try
            {
                response.ErrorMessage.Should().BeNullOrEmpty();
                Log.Information("Successfully validate no error messages - Actual Error: {ErrorMessage}", response.ErrorMessage ?? "None");
            }
            catch (AssertionException)
            {
                Log.Error("Fail to validate no error messages - Actual Error: {ErrorMessage}", response.ErrorMessage);

                throw;
            }
        }

        // Validates that the response status code is Created (201) and there are no error messages
        public static void ValidateOkResponse(RestResponse<User> response)
        {

            try
            {
                response.StatusCode.Should().Be(HttpStatusCode.Created);
                Log.Information("Successfully validate API response - Expected Status: Created (201), Actual: {StatusCode}", response.StatusCode);
            }
            catch (AssertionException)
            {
                Log.Information("Fail to validate API response - Expected Status: Created (201), Actual: {StatusCode}", response.StatusCode);

                throw;
            }

            try
            {
                response.ErrorMessage.Should().BeNullOrEmpty();
                Log.Information("Successfully validate no error messages - Actual Error: {ErrorMessage}", response.ErrorMessage ?? "None");
            }
            catch (AssertionException)
            {
                Log.Information("Fail to validate no error messages - Actual Error: {ErrorMessage}", response.ErrorMessage ?? "None");

                throw;
            }
        }

        // Validates that each user in the response has valid properties
        public static void ValidateUser(RestResponse<List<User>> response)
        {
            foreach (var user in response.Data!)
            {
                try
                {
                    user.Id.Should().BeGreaterThan(0);
                    user.Name.Should().NotBeNullOrWhiteSpace();
                    user.Username.Should().NotBeNullOrWhiteSpace();
                    user.Email.Should().NotBeNullOrWhiteSpace();
                    user.Address.Should().NotBeNull();
                    user.Phone.Should().NotBeNullOrWhiteSpace();
                    user.Website.Should().NotBeNullOrWhiteSpace();
                    user.Company.Should().NotBeNull();

                    Log.Information("Successfully validate each user: ID {UserId}, Name {UserName}", user.Id, user.Name);
                }
                catch (AssertionException)
                {
                    Log.Error("Fail to validate user: ID {UserId}, Name {UserName}", user.Id, user.Name);

                    throw;
                }
            }
        }

        // Validates that the Content-Type header in the response is "application/json"
        public static void ValidateContentTypeHeader(RestResponse<List<User>> response)
        {
            try
            {
                response.ContentType.Should().Be("application/json");
                Log.Information("Successfully validate Content Type - Expected: application/json, Actual: {ContentType}", response.ContentType);
            }
            catch (AssertionException)
            {
                Log.Error("Fail to validate Content Type - Expected: application/json, Actual: {ContentType}", response.ContentType);

                throw;
            }
        }

        // Validates that the response contains exactly 10 users
        public static void ValidateTenUsers(RestResponse<List<User>> response)
        {
            try
            {
                response.Data.Should().HaveCount(10);
                Log.Information("Successfully validate User List Count - Expected: 10, Actual: {Count}", response.Data!.Count);
            }
            catch (AssertionException)
            {
                Log.Error("Fail to validate User List Count - Expected: 10, Actual: {Count}", response.Data!.Count);

                throw;
            }
        }

        // Validates that all user IDs in the response are unique
        public static void ValidateUserDistinct(RestResponse<List<User>> response)
        {
            try
            {
                response.Data!.Select(user => user.Id).Should().OnlyHaveUniqueItems();
                Log.Information("Successfully validate that All users IDs are unique");
            }
            catch (AssertionException)
            {
                Log.Error("Fail to validate all users IDs for Uniqueness");
                throw;
            }
        }

        // Validates that all users in the response have non-empty Name and Username
        public static void ValidateUsersNameAndUsername(RestResponse<List<User>> response)
        {
            try
            {
                response.Data.Should().AllSatisfy(user =>
                {
                    user.Name.Should().NotBeNullOrWhiteSpace();
                    user.Username.Should().NotBeNullOrWhiteSpace();
                    Log.Information("Successfuly validate non-empty users: User Name {User} and Username {UserName}", user.Name, user.Username);
                });
            }
            catch (AssertionException)
            {
                Log.Error("Fail to validate non-empty users: User Name and Username ");

                throw;
            }
        }

        // Validates that all users in the response have a non-empty Company Name
        public static void ValidateUsersCompanyName(RestResponse<List<User>> response)
        {
            try
            {
                response.Data.Should().AllSatisfy(user =>
                {
                    user.Company!.Name.Should().NotBeNullOrWhiteSpace();
                    Log.Information("Successfuly validate users have company name - User: ID {UserId}, Name: {UserName}, have Company name: {CompanyName}", user.Id, user.Name, user.Company);
                });
            }
            catch (AssertionException)
            {
                Log.Error("Fail to validate each user have Company name");

                throw;
            }
        }

        // Validates that the response content is not empty
        public static void ValidateResponseNotEmpty(RestResponse<User> response)
        {
            try
            {
                response.Content.Should().NotBeNullOrEmpty();
                Log.Information("Successfuly validate Response Content - Expected: non-empty, Actual: {ContentType}", response.Content);
            }
            catch (AssertionException)
            {
                Log.Error("Fail to validate Response Content - Expected: non-empty, Actual: {ContentType}", response.Content);

                throw;
            }
        }

        // Validates that the response contains a valid Id value
        public static void ValidateResponseContainsId(RestResponse<User> response)
        {
            try
            {
                response.Data!.Id.Should().BeGreaterThan(0);
                Log.Information("Successfully validate that the response contains a valid Id value: {UserId}", response.Data!.Id);
            }
            catch (AssertionException)
            {
                Log.Error("Fail to validate that the response contains a valid Id value: {UserId}", response.Data!.Id);

                throw;
            }
        }

        // Validates that the response status code is Not Found(404) and there are no error message
        public static void ValidateNotFoundResponse(RestResponse response)
        {
            try
            {
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
                Log.Information("Successfuly validate Status Code - Expected: NotFound, Actual: {StatusCode}", response.StatusCode);
            }
            catch (AssertionException)
            {
                Log.Error("Fail to validate Status Code - Expected: NotFound, Actual: {StatusCode}", response.StatusCode);

                throw;
            }

            try
            {
                response.ErrorMessage.Should().BeNullOrEmpty();
                Log.Information("Successfuly validate no error messages - Actual Error: {ErrorMessage}", response.ErrorMessage ?? "None");
            }
            catch (AssertionException)
            {
                Log.Error("Fail to validate no error messages - Actual Error: {ErrorMessage}", response.ErrorMessage ?? "None");

                throw;
            }
        }
    }
}
