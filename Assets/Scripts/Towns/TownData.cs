using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTownData", menuName = "Towns/TownData")]
public class TownData : ScriptableObject
{
    [SerializeField] private TownName townName;

    [SerializeField] private List<PersonData> locals = new List<PersonData>();
    [SerializeField] private List<PersonData> specialPersons = new List<PersonData>();
    [SerializeField] private List<float> specialPersonShowRate = new List<float>();
    [SerializeField] private List<PersonData> tourists = new List<PersonData>();
    [Header("Higher Number = More Difficult")]
    [SerializeField, Range(-2f,3f)] private float addedDifficulty;

    // 
    // Accessors
    //
    public TownName TownName => townName;

    public IReadOnlyList<PersonData> Locals => locals;
    public IReadOnlyList<PersonData> SpecialPersons => specialPersons;
    public IReadOnlyList<PersonData> Tourists => tourists;
    public IReadOnlyList<float> SpecialPersonShowRate => specialPersonShowRate;

    public float AddedDifficulty => addedDifficulty;

    public void ShuffleLocals()
    {
        RNG.Shuffle(locals);
    }
}
