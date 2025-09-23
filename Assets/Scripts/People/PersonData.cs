using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPersonData", menuName = "People/PersonData")]
public class PersonData : ScriptableObject
{
    [SerializeField, Range(0f, 10f)] private float richPreference;
    [SerializeField, Range(0f, 10f)] private float spicyPreference;
    [SerializeField, Range(0f, 10f)] private float meatyPreference;
    [SerializeField, Range(0f, 10f)] private float fishyPreference;
    [SerializeField, Range(0f, 10f)] private float umamiPreference;
    [SerializeField, Range(0f, 10f)] private float hunger;
    [SerializeField, Range(0f, 10f)] private float sourPreference;
    [SerializeField, Range(0f, 10f)] private float sweetPreference;

    [SerializeField] private List<IngredientData> likes = new List<IngredientData>();
    [SerializeField] private List<IngredientData> loves = new List<IngredientData>();
    [SerializeField] private List<IngredientData> dislikes = new List<IngredientData>();

    [SerializeField] private List<Sprite> possibleSprites = new List<Sprite>();

    //
    // Accessors
    //
    public float RichPreference => richPreference;
    public float SpicyPreference => spicyPreference;
    public float MeatyPreference => meatyPreference;
    public float FishyPreference => fishyPreference;
    public float UmamiPreference => umamiPreference;
    public float Hunger => hunger;
    public float SourPreference => sourPreference;
    public float SweetPreference => sweetPreference;

    public IReadOnlyList<IngredientData> Likes => likes;
    public IReadOnlyList<IngredientData> Loves => loves;
    public IReadOnlyList<IngredientData> Dislikes => dislikes;

    public IReadOnlyList<Sprite> PossibleSprites => possibleSprites;
}
