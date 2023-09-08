using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Turkey's screen.
    /// </summary>
    public sealed class TurkeysScreen : Screen
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
        public TurkeysScreen(IDataService dataService, ISettingsService settingsService)
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
                _settingsService.ConsoleColorUpdate(ScreenEnum.Turkeys_Screen);
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. List all turkeys");
                Console.WriteLine("2. Create a new turkey");
                Console.WriteLine("3. Delete existing turkey");
                Console.WriteLine("4. Modify existing turkey");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    TurkeyScreenChoices choice = (TurkeyScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case TurkeyScreenChoices.List:
                            ListTurkey();
                            break;

                        case TurkeyScreenChoices.Create:
                            AddTurkey();
                            break;

                        case TurkeyScreenChoices.Delete:
                            DeleteTurkey();
                            break;

                        case TurkeyScreenChoices.Modify:
                            EditTurkeyMain();
                            break;

                        case TurkeyScreenChoices.Exit:
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
        /// List all turkey's.
        /// </summary>
        private void ListTurkey()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Turkeys is not null &&
                _dataService.Animals.Mammals.Turkeys.Count > 0)
            {
                Console.WriteLine("Here's a list of turkey's:");
                int i = 1;
                foreach (Turkey turkey in _dataService.Animals.Mammals.Turkeys)
                {
                    Console.Write($"Turkey number {i}, ");
                    turkey.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of turkey's is empty.");
            }
        }

        /// <summary>
        /// Add a turkey.
        /// </summary>
        private void AddTurkey()
        {
            try
            {
                Turkey turkey = AddEditTurkey();
                _dataService?.Animals?.Mammals?.Turkeys?.Add(turkey);
                Console.WriteLine("Turkey with name: {0} has been added to a list of turkey's", turkey.Name);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes a turkey.
        /// </summary>
        private void DeleteTurkey()
        {
            try
            {
                Console.Write("What is the name of the turkey you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Turkey? turkey = (Turkey?)(_dataService?.Animals?.Mammals?.Turkeys
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (turkey is not null)
                {
                    _dataService?.Animals?.Mammals?.Turkeys?.Remove(turkey);
                    Console.WriteLine("Turkey with name: {0} has been deleted from a list of Turkeys", turkey.Name);
                }
                else
                {
                    Console.WriteLine("Turkey not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing turkey after choice made.
        /// </summary>
        private void EditTurkeyMain()
        {
            try
            {
                Console.Write("What is the name of the turkey you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Turkey? turkey = (Turkey?)(_dataService?.Animals?.Mammals?.Turkeys?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (turkey is not null)
                {
                    Turkey turkeyEdited = AddEditTurkey();
                    turkey.Copy(turkeyEdited);
                    Console.Write("Turkey after edit:");
                    turkey.Display();
                }
                else
                {
                    Console.WriteLine("Turkey not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edit specific turkey.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Turkey AddEditTurkey()
        {
            Console.Write("What name of the turkey? ");
            string? name = Console.ReadLine();
            Console.Write("What is the turkey's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("What is the turkey's color? ");
            string? color = Console.ReadLine();
            Console.Write("What is the turkey's sound? ");
            string? sound = Console.ReadLine();
            Console.Write("What is the turkey's egg production rate? ");
            string? eggProductionRateAsString = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (color is null)
            {
                throw new ArgumentNullException(nameof(color));
            }
            if (sound is null)
            {
                throw new ArgumentNullException(nameof(sound));
            }
            if (eggProductionRateAsString is null)
            {
                throw new ArgumentNullException(nameof(eggProductionRateAsString));
            }
            int age = Int32.Parse(ageAsString);
            int eggProductionRate = Int32.Parse(eggProductionRateAsString);
            Turkey turkey = new Turkey(name, age, color, sound, eggProductionRate);
            return turkey;
        }

        #endregion // Private Methods
    }
}
