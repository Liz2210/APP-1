namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a Anteater.
/// </summary>
public interface IAnteater : IMammal
{
    #region Interface Members
    /// <summary>
    /// Ctor
    /// </summary>
    public int SnoutLength { get; set; }
    public int Size { get; set; }
    public string Diet { get; set; }

    #endregion // Interface Members
}
