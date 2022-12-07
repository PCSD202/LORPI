namespace LORPI.Models;

using Newtonsoft.Json;
using System;

internal class ParseStringConverter : JsonConverter {
    public ParseStringConverter(){}
    public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer) {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        long l;
        if (Int64.TryParse(value, out l)) {
            return l;
        }

        throw new Exception("Cannot unmarshal type long");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer) {
        if (untypedValue == null) {
            serializer.Serialize(writer, null);
            return;
        }

        var value = (long)untypedValue;
        serializer.Serialize(writer, value.ToString());
        return;
    }
}

public record AssetHeader {
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
    public bool Invalid { get; set; }

}