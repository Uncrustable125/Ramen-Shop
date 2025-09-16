
using System.Collections.Generic;
using UnityEngine;

public class IngredientDatabase : MonoBehaviour
{
    public static IngredientDatabase Instance;
    [Header("Ingredient Assets")]
    public List<Noodles> allNoodles;
    public List<Toppings> allToppings;
    public List<Broth> allBroths;
    public List<Protien> allProtiens;
    public List<AromaticOil> allAromaticOils;
    public List<Tare> allTares;
    List<Ingredient> all = new List<Ingredient>();

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        all.AddRange(allNoodles);
        all.AddRange(allToppings);
        all.AddRange(allBroths);
        all.AddRange(allProtiens);
        all.AddRange(allAromaticOils);
        all.AddRange(allTares);
    }
    public Ingredient PickRandomIngredient()
    {
        int index = Random.Range(0, all.Count);
        return all[index];
    }
    public Ramen GenerateRandomRamenBowl()
    {
        Ramen ramen = new Ramen("Random Bowl");
        int index = Random.Range(0, allNoodles.Count);
        ramen.Ingredients.Add(allNoodles[index]);
        index = Random.Range(0, allToppings.Count);
        ramen.Ingredients.Add(allToppings[index]);
        index = Random.Range(0, allBroths.Count);
        ramen.Ingredients.Add(allBroths[index]);
        index = Random.Range(0, allProtiens.Count);
        ramen.Ingredients.Add(allProtiens[index]);
        index = Random.Range(0, allAromaticOils.Count);
        ramen.Ingredients.Add(allAromaticOils[index]);
        index = Random.Range(0, allTares.Count);
        ramen.Ingredients.Add(allTares[index]);

        return ramen;
    }
}
