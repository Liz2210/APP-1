using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Hedgehog class.
/// </summary>
public class Hedgehog : MammalBase, IHedgehog
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
        Console.WriteLine($"My name is: {Name}, my age is: {Age}, my color is: {Color}, my spike lenght is {SpikeLength}, my favorite foods is {FavoriteFoods}");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IHedgehog ad)
        {
            base.Copy(animal);
            Name = ad.Name;
            Age = ad.Age;
            Color = ad.Color;
            SpikeLength = ad.SpikeLength;
            FavoriteFoods = ad.FavoriteFoods;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public string Color { get; set; }
    public int SpikeLength { get; set; }
    public string FavoriteFoods { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="color">Color</param>
    /// <param name="spikeLength">SpikeLength</param>
    /// <param name="favoriteFoods">FavoriteFoods</param>
    public Hedgehog(string name, int age, string color, int spikeLength, string favoriteFoods)
    {
        Name = name;
        Age = age;
        Color = color;
        SpikeLength = spikeLength;
        FavoriteFoods = favoriteFoods;
    }

    #endregion // Ctors And Properties
}
