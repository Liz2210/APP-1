using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System;
using System.Data;

namespace SampleHierarchies.Gui;

/// <summary>
/// Settings screen class.
/// </summary>
public sealed class SettingsScreen : Screen
{
    #region Properties And Ctor
     
    /// <summary>
    /// Data service.
    /// </summary>

    private readonly ISettingsService _settingsService;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public SettingsScreen(
        ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.ConsoleColorUpdate(ScreenEnum.Settings_Screen);
            Console.WriteLine();
            Console.WriteLine("Your available displays: ");
            ShowDisplayes();
            Console.WriteLine("0. Exit");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate user choice
            try
            {
                if (choiceAsString == null) throw new ArgumentNullException(nameof(choiceAsString));

                int choice = int.Parse(choiceAsString);

                if (choice >= 1 && choice <= 8) SetConsoleColor((ScreenEnum) choice);
                else if(choice == 0) { return; } 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid choice. Try again. {ex.Message} ");
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods


    private void ShowDisplayes()
    {
        var EnumList = Enum.GetValues(typeof(ScreenEnum));

        for (int i = 0; i < EnumList.Length; i++)
        {
            Console.WriteLine($"{1 + i}. {EnumList.GetValue(i)}");
        }
    }

    private void SetConsoleColor(ScreenEnum screen)
    {
        try
        {
            Console.Write("Write new color for display: ");
            string? colorAsString = Console.ReadLine();
            if (colorAsString == null) throw new ArgumentNullException(nameof(colorAsString));
            ConsoleColor newScreenColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorAsString);
            _settingsService.SetColor(screen, newScreenColor);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Invalid Input. Try again. {ex.Message}");
        }
    }

    #endregion // Private Methods
}