namespace LORPI.Models;

using Newtonsoft.Json;


public class Entitlement {
    [JsonProperty("itemNumber")]
    public string ItemNumber { get; set; }
    
    [JsonProperty("startDate")]
    public DateTimeOffset StartDate { get; set; }
    
    [JsonProperty("endDate")]
    public DateTimeOffset EndDate { get; set; }
    
    [JsonProperty("entitlementType")]
    public string EntitlementType { get; set; }
    
    [JsonProperty("serviceLevelCode")]
    public string ServiceLevelCode { get; set; }
    
    [JsonProperty("serviceLevelDescription")]
    public string ServiceLevelDescription { get; set; }
    
    [JsonProperty("serviceLevelGroup")]
    public string ServiceLevelGroup { get; set; }
}