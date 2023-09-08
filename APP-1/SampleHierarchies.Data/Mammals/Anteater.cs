using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Anteater class.
/// </summary>
public class Anteater : MammalBase, IAnteater
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
        Console.WriteLine($"My name is: {Name}, my age is: {Age}, my snout leght is {SnoutLength}, my size is {Size}, my diet is {Diet} ");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IAnteater ad)
        {
            base.Copy(animal);
            Name = ad.Name;
            Age = ad.Age;
            Size = ad.Size;
            SnoutLength = ad.SnoutLength;
            Diet = ad.Diet;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public int SnoutLength { get; set; }
    public int Size { get; set; }
    public string Diet { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="furColor">FurColor</param>
    /// <param name="name">Name</param>
    /// <param name="snoutLength">SnoutLength</param>
    /// <param name="size ">Size</param>
    public Anteater(string name, int age, int snoutLength, int size, string diet)
    {
        Name = name;
        Age = age;
        SnoutLength = snoutLength;
        Size = size;
        Diet = diet;
    }

    #endregion // Ctors And Properties
}
