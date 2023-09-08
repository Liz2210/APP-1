using Newtonsoft.Json;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using Newtonsoft;
using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using System.Diagnostics;

namespace SampleHierarchies.Services;

/// <summary>
/// Settings service.
/// </summary>
public class SettingsService : ISettingsService
{
    #region ISettings Implementation

    /// <inheritdoc/>
    /// Method used to read data from json
    public ISettings? Read(string? jsonPath)
    {
        try
        {
            if (jsonPath == null) new ArgumentNullException(nameof(jsonPath));
            string? jsonSource = File.ReadAllText(jsonPath);
            Settings? jsonContent = JsonConvert.DeserializeObject<Settings>(jsonSource);
            if (jsonContent == null) new ArgumentNullException(nameof(jsonContent));
            return jsonContent;
        }
        catch
        {
            Console.WriteLine("Data reading was not successful.");
            return new Settings();
        }
    }

    /// Method used to write data to json
    public void Write(ISettings settings, string? jsonPath)
    {
        try
        {
            if (jsonPath == null) throw new ArgumentNullException(nameof(jsonPath));
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(settings));
            Console.WriteLine("Data saving to: '{0}' was successful.", jsonPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Data saving was not successful.");
            Debug.WriteLine(ex.Message);
        }
    }
    /// Method used to read and update data from json
    public void ConsoleColorUpdate(ScreenEnum screenEnum)
    {
        try
        {
            ISettings? Settings = Read("Colors.json");
            Console.ForegroundColor = Settings?.ScreensColor[screenEnum] ?? ConsoleColor.White;
        }
        catch (Exception ex)
        {
            Console.ResetColor();
            Console.WriteLine("Data reading from json was not successful.");
            Debug.WriteLine(ex.Message);
        }
    }
    /// Method used to edit json data
    public void SetColor(ScreenEnum screensEnum, ConsoleColor newConsoleColor)
    {
        ISettings settings = Read("Colors.json") ?? new Settings();
        settings.ScreensColor[screensEnum] = newConsoleColor;

        Write(settings, "Colors.json");
    }



    #endregion // ISettings Implementation
}