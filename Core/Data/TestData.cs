using System.Text.Json.Serialization;

namespace Core.Data
{
    /// <summary>
    /// Class that represents test parameters data from a JSON file.
    /// </summary>
    public class TestData
    {
        // Constructor to initialize data properties from JSON
        public TestData(string careersPage, List<string> searchPage)
        => (CareersPage, SearchPage) = (careersPage, searchPage);

        // Property for the careers page specified in the JSON
        [JsonPropertyName("careersPage")]
        public string CareersPage { get; }

        // Property for the search page parameters specified in the JSON
        [JsonPropertyName("searchPage")]
        public List<string> SearchPage { get; }
    }
}