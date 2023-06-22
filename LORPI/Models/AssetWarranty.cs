using System.ComponentModel;
using Newtonsoft.Json;

namespace LORPI.Models;

public class AssetWarranty {
    [JsonProperty("id")]
    public long? Id { get; set; }

    [JsonProperty("serviceTag")]
    public string ServiceTag { get; set; }

    [JsonProperty("orderBuid")]
    public long? OrderBuid { get; set; }

    [JsonProperty("shipDate")]
    public DateTimeOffset? ShipDate { get; set; }

    [JsonProperty("productCode")]
    public string? ProductCode { get; set; }

    [JsonProperty("localChannel")]
    public string? LocalChannel { get; set; }

    [JsonProperty("productId")]
    public string? ProductId { get; set; }

    [JsonProperty("productLineDescription")]
    public string? ProductLineDescription { get; set; }

    [JsonProperty("productFamily")]
    public string? ProductFamily { get; set; }

    [JsonProperty("systemDescription")]
    public string? SystemDescription { get; set; }

    [JsonProperty("productLobDescription")]
    public string? ProductLobDescription { get; set; }

    [JsonProperty("countryCode")]
    public string? CountryCode { get; set; }

    [JsonProperty("duplicated")]
    public bool? Duplicated { get; set; }

    [JsonProperty("invalid")]
    [DefaultValue(true)]
    public bool Invalid { get; set; } = true;
    
    [JsonProperty("entitlements")]
    public List<Entitlement> Entitlements { get; set; }
}