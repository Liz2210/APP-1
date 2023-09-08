using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Mammals collection.
/// </summary>
public interface IMammals
{
    #region Interface Members

    /// <summary>
    /// Animals collection.
    /// </summary>
    List<IDog> Dogs { get; set; }
    List<IAnteater> Anteaters { get; set; }
    List<ITurkey> Turkeys { get; set; }
    List<IHedgehog> Hedgehogs { get; set; }

    #endregion // Interface Members
}
