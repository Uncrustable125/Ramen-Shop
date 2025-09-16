using 
    
    UnityEngine;

[CreateAssetMenu(fileName = "NewNoodle", menuName = "Ingredients/Noodle")]

public class Noodles : Ingredient
{
    public enum NoodleType { Ramen, Udon, Soba }
    public NoodleType Type { get; private set; }
    public Noodles(NoodleType type) : base(type.ToString())
    {
        Type = type;
    }


}
