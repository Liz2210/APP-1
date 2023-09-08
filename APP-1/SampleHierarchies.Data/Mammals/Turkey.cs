using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Turkey class.
/// </summary>
public class Turkey : MammalBase, ITurkey
{
    #region Public Methods

    /// <inheritdoc/>
    public override void MakeSound()
    {
        Console.WriteLine("My name is: {0} and I am barking", Name);
    }

    /// <inheritdoc/>
    public override void Move()
    {
        Console.WriteLine("My name is: {0} and I am running", Name);
    }

    /// <inheritdoc/>
    public override void Display()
    {
        Console.WriteLine($"My name is: {Name}, my age is: {Age}, my color is: {Color}, my sound is {Sound}, my egg production rate is {EggProductionRate}");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is ITurkey ad)
        {
            base.Copy(animal);
            Name = ad.Name;
            Age = ad.Age;
            Color = ad.Color;
            Sound = ad.Sound;
            EggProductionRate = ad.EggProductionRate;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public string Color { get; set; }
    public string Sound { get; set; }
    public int EggProductionRate { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="color">Color</param>
    /// <param name="sound">Sound</param>
    /// <param name="eggProductionRate">EggProductionRate</param>
    public Turkey(string name, int age, string color, string sound, int eggProductionRate)
    {
        Name = name;
        Age = age;
        Color = color;
        Sound = sound;
        EggProductionRate = eggProductionRate;
    }

    #endregion // Ctors And Properties
}
