using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Mammals collection.
/// </summary>
public class Mammals : IMammals
{
    #region IMammals Implementation

    /// <inheritdoc/>
    public List<IDog> Dogs { get; set; }
    public List<IAnteater> Anteaters { get; set; }
    public List<ITurkey> Turkeys { get; set; }
    public List<IHedgehog> Hedgehogs { get; set; }

    #endregion // IMammals Implementation

    #region Ctors

    /// <summary>
    /// Default ctor.
    /// </summary>
    public Mammals()
    {
        Dogs = new List<IDog>();
        Anteaters = new List<IAnteater>();
        Turkeys = new List<ITurkey>();
        Hedgehogs = new List<IHedgehog>();
    }

    #endregion // Ctors
}
