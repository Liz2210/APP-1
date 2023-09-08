using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Hedgehog's screen.
    /// </summary>
    public sealed class HedgehogsScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private IDataService _dataService;
        private ISettingsService _settingsService;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public HedgehogsScreen(IDataService dataService, ISettingsService settingsService)
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
                _settingsService.ConsoleColorUpdate(ScreenEnum.Hedgehogs_Screen);
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. List all hedgehogs");
                Console.WriteLine("2. Create a new hedgehog");
                Console.WriteLine("3. Delete existing hedgehog");
                Console.WriteLine("4. Modify existing hedgehog");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    HedgehogScreenChoices choice = (HedgehogScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case HedgehogScreenChoices.List:
                            ListHedgehog();
                            break;

                        case HedgehogScreenChoices.Create:
                            AddHedgehog();
                            break;

                        case HedgehogScreenChoices.Delete:
                            DeleteHedgehog();
                            break;

                        case HedgehogScreenChoices.Modify:
                            EditHedgehogMain();
                            break;

                        case HedgehogScreenChoices.Exit:
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
        /// List all hedgehog's.
        /// </summary>
        private void ListHedgehog()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Hedgehogs is not null &&
                _dataService.Animals.Mammals.Hedgehogs.Count > 0)
            {
                Console.WriteLine("Here's a list of hedgehogs:");
                int i = 1;
                foreach (Hedgehog hedgehog in _dataService.Animals.Mammals.Hedgehogs)
                {
                    Console.Write($"Hedgehog number {i}, ");
                    hedgehog.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of hedgehogs is empty.");
            }
        }

        /// <summary>
        /// Add a hedgehog.
        /// </summary>
        private void AddHedgehog()
        {
            try
            {
                Hedgehog hedgehog = AddEditHedgehog();
                _dataService?.Animals?.Mammals?.Hedgehogs?.Add(hedgehog);
                Console.WriteLine("Hedgehog with name: {0} has been added to a list of hedgehogs", hedgehog.Name);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes a hedgehog.
        /// </summary>
        private void DeleteHedgehog()
        {
            try
            {
                Console.Write("What is the name of the hedgehog you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Hedgehog? hedgehog = (Hedgehog?)(_dataService?.Animals?.Mammals?.Hedgehogs
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (hedgehog is not null)
                {
                    _dataService?.Animals?.Mammals?.Hedgehogs?.Remove(hedgehog);
                    Console.WriteLine("Hedgehog with name: {0} has been deleted from a list of hedgehogs", hedgehog.Name);
                }
                else
                {
                    Console.WriteLine("Hedgehog not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing hedgehog after choice made.
        /// </summary>
        private void EditHedgehogMain()
        {
            try
            {
                Console.Write("What is the name of the hedgehog you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Hedgehog? hedgehog = (Hedgehog?)(_dataService?.Animals?.Mammals?.Hedgehogs?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (hedgehog is not null)
                {
                    Hedgehog hedgehogEdited = AddEditHedgehog();
                    hedgehog.Copy(hedgehogEdited);
                    Console.Write("Hedgehog after edit:");
                    hedgehog.Display();
                }
                else
                {
                    Console.WriteLine("Hedgehog not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edit specific hedgehog.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Hedgehog AddEditHedgehog()
        {
            Console.Write("What name of the hedgehog? ");
            string? name = Console.ReadLine();
            Console.Write("What is the hedgehog's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("What is the hedgehog's color? ");
            string? color = Console.ReadLine();
            Console.Write("What is the hedgehog's spike length? ");
            string? spikeLengthAsString = Console.ReadLine();
            Console.Write("What is the hedgehog's favorite food? ");
            string? favoriteFood = Console.ReadLine();

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
            if (spikeLengthAsString is null)
            {
                throw new ArgumentNullException(nameof(spikeLengthAsString));
            }
            if (favoriteFood is null)
            {
                throw new ArgumentNullException(nameof(favoriteFood));
            }
            int age = int.Parse(ageAsString);
            int spikeLength = int.Parse(spikeLengthAsString);
            Hedgehog hedgehog = new Hedgehog(name, age, color, spikeLength, favoriteFood);
            return hedgehog;
        }

        #endregion // Private Methods
    }
}
