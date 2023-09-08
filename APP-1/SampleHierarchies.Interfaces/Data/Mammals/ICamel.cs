namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a Hedgehog.
/// </summary>
public interface IHedgehog : IMammal
{
    #region Interface Members
    /// <summary>
    /// Ctor
    /// </summary>
    public string Color { get; set; }
    public int SpikeLength { get; set; }
    public string FavoriteFoods { get; set; }

    #endregion // Interface Members
}
