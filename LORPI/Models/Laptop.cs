namespace LORPI.Models;

public enum ReasonForCheckIn
{
    WaitingForParts,
    ReturnToDepot,
    WaitingForReturn,
    NeedsImaging,
    WaitingForOnSiteRepair,
    WaitingForDiagnostics,
    HighPriorityRepair,
    HighPriorityRepairPickup,
    AssignedToOtherTenant,
    LeftHinge
}

public enum ProblemFrequency
{
    AllTheTime,
    Intermittent
}

public class Laptop
{
    public override string ToString() {
        return $"Laptop {ServiceTag}: {Shelf} {SlotNumber}";
    }
    
    
    public string Id { get; set; }
    public string ServiceTag { get; set; } = null!;

    public int SlotNumber { get; set; }

    public string Shelf { get; set; } = null!;
    
    public AssetHeader AssetHeader { get; set; }
    public AssetWarranty AssetWarrantyHeader { get; set; }
    
    public string CheckedInBy { get; set; }
    
    public string RemovedBy { get; set; }
    
    public string Notes { get; set; }

    public ProblemFrequency ProblemFrequency { get; set; }

    public ReasonForCheckIn ReasonForCheckIn { get; set; }

    public string? ProblemDescription { get; set; }
    
    public string? ShippingID { get; set; }
    
    public DateTime CheckedInDateTime { get; set; }

}