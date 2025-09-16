
using System.Collections.Generic;
using UnityEngine;


public class Ramen
{
    //preference variables
    [Range(0f, 10f)] public float rich; //rich or light
    [Range(0f, 10f)] public float spicy;
    [Range(0f, 10f)] public float meaty;
    [Range(0f, 10f)] public float fishy;
    [Range(0f, 10f)] public float umami;
    [Range(0f, 10f)] public float sweet;
    [Range(0f, 10f)] public float sour;
    [Range(0f, 10f)] public float size;

    //Will add value to ramen score
    //Proper values will be needed to sell high end bowls
    [Range(-1f, 2f)] public float presentation;
    [Range(-1f, 2f)] public float quality;

    //Want to handle aroma differently
    //Something like favorite ingredients
    [Range(0f, 3f)] public float aroma;

    [Range(0f, 10f)] public float timeToCook;
 // [Range(0f, 10f)] public float Popularity;

    public string bowlName; // Optional: give each ramen a name
    public List<Ingredient> Ingredients { get; private set; }

    public Ramen(string name)
    {
        bowlName = name;
        Ingredients = new List<Ingredient>();
    }

    public void AddIngredient(Ingredient ingredient)
    {
        Ingredients.Add(ingredient);
    }
    public void RamenProfile()
    {
        for (int i = 0; i < Ingredients.Count; i++)
        {
            this.rich = Mathf.Min(this.rich + Ingredients[i].rich  / 2, 10f);
            this.spicy = Mathf.Min(this.spicy + Ingredients[i].spicy / 2, 10f);
            this.meaty = Mathf.Min(this.meaty + Ingredients[i].meaty / 2, 10f);
            this.fishy = Mathf.Min(this.fishy + Ingredients[i].fishy / 2, 10f);
            this.umami = Mathf.Min(this.umami + Ingredients[i].umami / 2, 10f);
            this.sweet = Mathf.Min(this.sweet + Ingredients[i].sweet / 2, 10f);
            this.sour = Mathf.Min(this.sour + Ingredients[i].sour / 2, 10f); 
            this.size = Mathf.Min(this.size + Ingredients[i].size / 2, 10f);

            this.presentation = Mathf.Min(this.presentation + Ingredients[i].presentation, 4f);
            this.aroma = Mathf.Min(this.aroma + Ingredients[i].aroma, 4f);
            this.quality = Mathf.Min(this.quality + Ingredients[i].quality, 4f);
            this.timeToCook = this.timeToCook + Ingredients[i].timeToCook;

        }
        //this.bowlName = name;
    }
}
