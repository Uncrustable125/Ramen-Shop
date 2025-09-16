


using UnityEngine;

[CreateAssetMenu(fileName = "NewProtien", menuName = "Ingredients/Protien")]

public class Protien : Ingredient
{
    public enum ProtienType { Pork, Beef, Tofu, Chicken }
    public ProtienType Type { get; private set; }
    public Protien(ProtienType type) : base(type.ToString())
    {
        Type = type;
    }
    
    
}
