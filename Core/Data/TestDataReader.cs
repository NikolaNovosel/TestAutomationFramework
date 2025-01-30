using System.Text.Json;

namespace Core.Data
{
    /// </summary>
    /// Class for reading the parameters data for testing purposes
    /// </summary>
    public static class TestDataReader
    {
        // JSON content read from the configuration file
        private static readonly string _json = File.ReadAllText(Location.JsonTestData);

        // Singleton instance of the Data class
        private static TestData? _data;

        // Method to read and yield search page parameters from the JSON data
        public static IEnumerable<string> ReadSearchPage()
        {
            foreach (string parameter in _data!.SearchPage)
            {
                yield return parameter;
            }
        }

        // Method to deserialize JSON data into a Data object
        public static TestData? DeserializeData()
        {
            _data = JsonSerializer.Deserialize<TestData>(_json);

            return _data;
        }
    }
}
