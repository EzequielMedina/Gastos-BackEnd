using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class HttpClientWrapper : IDisposable
{
    private readonly HttpClient _httpClient;

    public HttpClientWrapper()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> GetAsync(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            // Handle exceptions
            throw new HttpRequestException($"Error getting data from {url}: {ex.Message}");
        }
    }

    public async Task<string> PostAsync(string url, string jsonContent)
    {
        try
        {
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            // Handle exceptions
            throw new HttpRequestException($"Error posting data to {url}: {ex.Message}");
        }
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
