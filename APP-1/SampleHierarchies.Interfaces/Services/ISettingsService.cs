using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Interfaces.Services;

public interface ISettingsService
{
    #region Interface Members

    /// Public Methods  
    public ISettings? Read(string jsonPath);
    public void Write(ISettings settings, string jsonPath);
    public void ConsoleColorUpdate(ScreenEnum screenEnum);
    public void SetColor(ScreenEnum screensEnum, ConsoleColor consoleColor);

    #endregion // Interface Members
}
