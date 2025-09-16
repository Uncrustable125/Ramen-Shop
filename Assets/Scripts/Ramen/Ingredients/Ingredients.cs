

using UnityEngine;

public abstract class Ingredient : ScriptableObject
{
    public string Name { get; private set; }

    protected Ingredient(string name)
    {
        Name = name;
    }
    [Range(0f, 10f)] public int rich; //rich or light
    [Range(0f, 10f)] public int spicy;
    [Range(0f, 10f)] public int meaty;
    [Range(0f, 10f)] public int fishy;
    [Range(0f, 10f)] public int umami;
    [Range(0f, 10f)] public int sweet;
    [Range(0f, 10f)] public int sour;
    [Range(0f, 10f)] public int size;

    //Will add value to ramen score
    //Proper values will be needed to sell high end bowls
    [Range(-1f, 4f)] public int presentation;
    [Range(-1f, 4f)] public int quality;

    //Want to handle aroma differently
    //Something like favorite ingredients
    [Range(-1f, 4f)] public int aroma;

    [Range(0f, 500f)] public int timeToCook;

    public bool meat;
    public bool egg;
    public bool gluten;
    public bool dairy;




}
