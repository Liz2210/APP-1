using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Anteater screen.
    /// </summary>
    public sealed class AnteatersScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private readonly IDataService _dataService;
        private readonly ISettingsService _settingsService;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public AnteatersScreen(IDataService dataService, ISettingsService settingsService)
        {
            _dataService = dataService;
            _settingsService = settingsService;
        }

        #endregion Properties And Ctor

        #region Public Methods

        /// <inheritdoc/>
        public override void Show()
        {
            while (true)
            {
                _settingsService.ConsoleColorUpdate(ScreenEnum.Anteaters_Screen);
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. List all anteaters");
                Console.WriteLine("2. Create a new anteater");
                Console.WriteLine("3. Delete existing anteater");
                Console.WriteLine("4. Modify existing anteater");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    AnteaterScreenChoices choice = (AnteaterScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case AnteaterScreenChoices.List:
                            ListAnteater();
                            break;

                        case AnteaterScreenChoices.Create:
                            AddAnteater();
                            break;

                        case AnteaterScreenChoices.Delete:
                            DeleteAnteater();
                            break;

                        case AnteaterScreenChoices.Modify:
                            EditAnteaterMain();
                            break;

                        case AnteaterScreenChoices.Exit:
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

        #region Private Methods

        /// <summary>
        /// List all anteater's.
        /// </summary>
        private void ListAnteater()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Anteaters is not null &&
                _dataService.Animals.Mammals.Anteaters.Count > 0)
            {
                Console.WriteLine("Here's a list of anteaters:");
                int i = 1;
                foreach (Anteater anteater in _dataService.Animals.Mammals.Anteaters)
                {
                    Console.Write($"Anteater number {i}, ");
                    anteater.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of anteaters is empty.");
            }
        }

        /// <summary>
        /// Add an anteater.
        /// </summary>
        private void AddAnteater()
        {
            try
            {
                Anteater anteater = AddEditAnteater();
                _dataService?.Animals?.Mammals?.Anteaters?.Add(anteater);
                Console.WriteLine("Anteater with name: {0} has been added to a list of anteaters", anteater.Name);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes an anteater.
        /// </summary>
        private void DeleteAnteater()
        {
            try
            {
                Console.Write("What is the name of the anteater you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Anteater? anteater = (Anteater?)(_dataService?.Animals?.Mammals?.Anteaters
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (anteater is not null)
                {
                    _dataService?.Animals?.Mammals?.Anteaters?.Remove(anteater);
                    Console.WriteLine("Anteater with name: {0} has been deleted from a list of Anteaters", anteater.Name);
                }
                else
                {
                    Console.WriteLine("Anteater not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing anteater after choice made.
        /// </summary>
        private void EditAnteaterMain()
        {
            try
            {
                Console.Write("What is the name of the anteater you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Anteater? anteater = (Anteater?)(_dataService?.Animals?.Mammals?.Anteaters?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (anteater is not null)
                {
                    Anteater anteaterEdited = AddEditAnteater();
                    anteater.Copy(anteaterEdited);
                    Console.Write("Anteater after edit:");
                    anteater.Display();
                }
                else
                {
                    Console.WriteLine("Anteater not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edits specific anteater.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Anteater AddEditAnteater()
        {
            Console.Write("What is the name of the anteater? ");
            string? name = Console.ReadLine();
            Console.Write("What is the anteater's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("What is the anteater's snout length? ");
            string? snoutLengthAsString = Console.ReadLine();
            Console.Write("What is the anteater's size? ");
            string? sizeAsString = Console.ReadLine();
            Console.Write("What is the anteater's diet? ");
            string? diet = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (snoutLengthAsString is null)
            {
                throw new ArgumentNullException(nameof(snoutLengthAsString));
            }
            if (sizeAsString is null)
            {
                throw new ArgumentNullException(nameof(sizeAsString));
            }
            if (diet is null)
            {
                throw new ArgumentNullException(nameof(diet));
            }
            int age = Int32.Parse(ageAsString);
            int size = Int32.Parse(sizeAsString);
            int snoutLength = Int32.Parse(snoutLengthAsString);
            Anteater anteater = new Anteater(name, age, snoutLength, size, diet);
            return anteater;
        }

        #endregion // Private Methods
    }
}
