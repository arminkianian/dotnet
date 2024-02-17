namespace WebApi.Helpers
{
    public class ElasticsearchConnectivityTester
    {
        private readonly HttpClient _httpClient;
        private readonly string _elasticsearchUri;

        public ElasticsearchConnectivityTester(string elasticsearchUri)
        {
            _elasticsearchUri = elasticsearchUri ?? throw new ArgumentNullException(nameof(elasticsearchUri));
            _httpClient = new HttpClient();
        }

        public async Task<bool> TestElasticsearchConnectivityAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_elasticsearchUri);

                // Check if the response is successful (status code 200-299)
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Log or handle any exceptions
                Console.WriteLine($"Failed to connect to Elasticsearch: {ex.Message}");
                return false;
            }
        }
    }
}
