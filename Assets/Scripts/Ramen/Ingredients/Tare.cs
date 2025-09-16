


using UnityEngine;

[CreateAssetMenu(fileName = "NewTare", menuName = "Ingredients/Tare")]

public class Tare : Ingredient
{
    public enum TareType { Shio, Shoyu, Miso, Spicy }
    public TareType Type { get; private set; }
    public Tare(TareType type) : base(type.ToString())
    {
        Type = type;
    }

}

