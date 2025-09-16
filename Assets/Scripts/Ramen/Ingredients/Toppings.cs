
using UnityEngine;

[CreateAssetMenu(fileName = "NewToppings", menuName = "Ingredients/Toppings")]

public class Toppings : Ingredient
{
    public enum ToppingsType { SoftBoiledEgg, HardBoiledEgg, GreenOnions, Nori }
    public ToppingsType Type { get; private set; }
    public Toppings(ToppingsType type) : base(type.ToString())
    {
        Type = type;
    }


}
