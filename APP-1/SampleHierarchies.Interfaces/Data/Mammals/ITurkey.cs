namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a Turkey.
/// </summary>
public interface ITurkey : IMammal
{
    #region Interface Members
    /// <summary>
    /// Ctor
    /// </summary>
    public string Color { get; set; }
    public string Sound { get; set; }
    public int EggProductionRate { get; set; }

    #endregion // Interface Members
}
