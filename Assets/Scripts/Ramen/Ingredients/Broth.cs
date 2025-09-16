


using UnityEngine;

[CreateAssetMenu(fileName = "NewBroth", menuName = "Ingredients/Broth")]

public class Broth : Ingredient
{
    public enum BrothType { Tonkotsu, Chicken, Vegtable, Seafood }
    public BrothType Type { get; private set; }
    public Broth(BrothType type) : base(type.ToString())
    {
        Type = type;
    }
}