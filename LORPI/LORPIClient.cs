using LORPI.Models;
using RestSharp;

namespace LORPI;

public class LORPIClient : IDisposable
{
    private readonly RestClient _client;

    public LORPIClient(string AuthKey, string BaseURL = "https://laptop-organizer-backend.carbun.xyz/api")
    {
        _client = new RestClient(BaseURL);
        _client.AddDefaultHeader("APIKey", AuthKey);
    }

    public IEnumerable<SystemOverview> GetSystemOverview() => _client.GetJson<IEnumerable<SystemOverview>>("Shelf/Overview")!;
    
    public IEnumerable<Laptop> GetLaptops() => _client.GetJson<IEnumerable<Laptop>>("laptop")!;
    public Task<IEnumerable<Laptop>> GetLaptopsAsync() => _client.GetJsonAsync<IEnumerable<Laptop>>("laptop")!;

    public Laptop? GetLaptop(string serviceTag) => _client.GetJson<Laptop>($"laptop/{serviceTag}");
    public Task<Laptop?> GetLaptopAsync(string serviceTag) => _client.GetJsonAsync<Laptop>($"laptop/{serviceTag}");

    public AssetWarranty GetWarrantyInfo(string serviceTag) => _client.GetJson<AssetWarranty>($"Warranty/{serviceTag}")!;
    public Task<AssetWarranty> GetWarrantyInfoAsync(string serviceTag) => _client.GetJsonAsync<AssetWarranty>($"Warranty/{serviceTag}")!;

    public bool ValidateServiceTag(string serviceTag) => _client.Get<bool>(new RestRequest($"Warranty/{serviceTag}/validate"))!;
    public Task<bool> ValidateServiceTagAsync(string serviceTag) => _client.GetAsync<bool>(new RestRequest($"Warranty/{serviceTag}/validate"))!;


    public List<AssetWarranty> BulkLookupServiceTags(List<string> serviceTags)
    {
        var request = new RestRequest($"Warranty/bulkLookup");
        request.AddJsonBody(serviceTags);
        var response = _client.Post<List<AssetWarranty>>(request);
        return response ?? new List<AssetWarranty>();
    }

    public async Task<List<AssetWarranty>> BulkLookupServiceTagsAsync(List<string> serviceTags)
    {
        var request = new RestRequest($"Warranty/bulkLookup");
        request.AddJsonBody(serviceTags);
        var response = await _client.PostAsync<List<AssetWarranty>>(request);
        return response ?? new List<AssetWarranty>();
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}