namespace SampleHierarchies.Interfaces.Data;
using Enums;
/// <summary>
/// Settings interface.
/// </summary>
public interface ISettings
{
    #region Interface Members

    /// <summary>
    /// ScreensColor
    /// </summary>
    Dictionary<ScreenEnum, ConsoleColor> ScreensColor { get; set; }

    #endregion // Interface Members
}

