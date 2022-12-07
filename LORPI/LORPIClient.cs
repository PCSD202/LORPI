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

    public IEnumerable<Laptop> GetLaptops() => _client.GetJson<IEnumerable<Laptop>>("laptop")!;
    public Task<IEnumerable<Laptop>> GetLaptopsAsync() => _client.GetJsonAsync<IEnumerable<Laptop>>("laptop")!;

    public Laptop? GetLaptop(string serviceTag) => _client.GetJson<Laptop>($"laptop/{serviceTag}");
    public Task<Laptop?> GetLaptopAsync(string serviceTag) => _client.GetJsonAsync<Laptop>($"laptop/{serviceTag}");

    public AssetWarranty GetWarrantyInfo(string serviceTag) => _client.GetJson<AssetWarranty>($"Warranty/{serviceTag}")!;
    public Task<AssetWarranty> GetWarrantyInfoAsync(string serviceTag) => _client.GetJsonAsync<AssetWarranty>($"Warranty/{serviceTag}")!;

    public bool ValidateServiceTag(string serviceTag) => _client.Get<bool>(new RestRequest($"Warranty/{serviceTag}/validate"))!;
    public Task<bool> ValidateServiceTagAsync(string serviceTag) => _client.GetAsync<bool>(new RestRequest($"Warranty/{serviceTag}/validate"))!;


    public void Dispose()
    {
        _client.Dispose();
    }
}