


using UnityEngine;

[CreateAssetMenu(fileName = "NewAromaticOil", menuName = "Ingredients/AromaticOil")]

public class AromaticOil : Ingredient
{

    public enum AromaticOilType { Garlic, Sesame, Chili }
    public AromaticOilType Type { get; private set; }
    public AromaticOil(AromaticOilType type) : base(type.ToString())
    {
        Type = type;
    }

}
