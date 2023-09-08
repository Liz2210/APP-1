using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Animals screen.
    /// </summary>
    private readonly DogsScreen _dogsScreen;
    private readonly AnteatersScreen _anteatersScreen;
    private readonly TurkeysScreen _turkeysScreen;
    private readonly HedgehogsScreen _hedgehogScreen;
    private readonly ISettingsService _settingsService;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    public MammalsScreen(DogsScreen dogsScreen, AnteatersScreen anteatersScreen, TurkeysScreen turkeysScreen, ISettingsService settingsService, HedgehogsScreen hedgehogScreen)
    {
        _settingsService = settingsService;
        _dogsScreen = dogsScreen;
        _anteatersScreen = anteatersScreen;
        _turkeysScreen = turkeysScreen;
        _hedgehogScreen = hedgehogScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.ConsoleColorUpdate(ScreenEnum.Mammals_Screen);
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Dogs");
            Console.WriteLine("2. Anteaters");
            Console.WriteLine("3. Turkeys");
            Console.WriteLine("4. Hedgehogs");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        _dogsScreen.Show(); break;
                    case MammalsScreenChoices.Anteaters:
                        _anteatersScreen.Show(); break;
                    case MammalsScreenChoices.Turkeys:
                        _turkeysScreen.Show(); break;
                    case MammalsScreenChoices.Hedgehogs:
                        _hedgehogScreen.Show(); break;
                    case MammalsScreenChoices.Exit:
                        Console.WriteLine("Going back to parent menu.");
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }

    #endregion // Public Methods
}
