using UnityEngine;

[CreateAssetMenu(fileName = "NewIngredient", menuName = "Ingredients/IngredientData")]
public class IngredientData : ScriptableObject
{
    [SerializeField] private string ingredientName;

    [SerializeField, Range(0f, 10f)] private float rich;
    [SerializeField, Range(0f, 10f)] private float spicy;
    [SerializeField, Range(0f, 10f)] private float meaty;
    [SerializeField, Range(0f, 10f)] private float fishy;
    [SerializeField, Range(0f, 10f)] private float umami;
    [SerializeField, Range(0f, 10f)] private float size;

    [SerializeField, Range(0f, 5f)] private float presentation;
    [SerializeField, Range(0f, 5f)] private float quality;
    [SerializeField, Range(0f, 5f)] private float aroma;

    [Header("Ramen Part")]
    [SerializeField] private bool broth;
    [SerializeField] private bool tare;
    [SerializeField] private bool noodles;
    [SerializeField] private bool protein;
    [SerializeField] private bool aromaticOil;
    [SerializeField] private bool topping;

    [Header("Contains")]
    [SerializeField] private bool egg;
    [SerializeField] private bool gluten;
    [SerializeField] private bool dairy;
    [SerializeField] private bool nut;
    [SerializeField] private bool meat;

    //
    // Accessors
    // 
    public string IngredientName => ingredientName;

    public float Rich => rich;
    public float Spicy => spicy;
    public float Meaty => meaty;
    public float Fishy => fishy;
    public float Umami => umami;
    public float Size => size;

    public float Presentation => presentation;
    public float Quality => quality;
    public float Aroma => aroma;

    public bool Broth => broth;
    public bool Tare => tare;
    public bool Noodles => noodles;
    public bool Protein => protein;
    public bool AromaticOil => aromaticOil;
    public bool Topping => topping;

    public bool Egg => egg;
    public bool Gluten => gluten;
    public bool Dairy => dairy;
    public bool Nut => nut;
    public bool Meat => meat;
}
