namespace tests
{
    public interface IGiveDetails
    {
        string Brand { get;}
        bool TotalLost { get;}
        bool NeedsRepair { get; set; }
        int EngineVolume { get; }
        bool CanFixTotalLost { get; }
    }
}