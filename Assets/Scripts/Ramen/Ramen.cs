
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ramen : MonoBehaviour
{
    //preference variables
    [Range(0f, 10f)] public float rich; //rich or light
    [Range(0f, 10f)] public float spicy;
    [Range(0f, 10f)] public float meaty;
    [Range(0f, 10f)] public float fishy;
    [Range(0f, 10f)] public float umami;
 //   [Range(0f, 10f)] public float sweet;
 //   [Range(0f, 10f)] public float sour;
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
    public List<IngredientData> Ingredients = new List<IngredientData>();

    public void InitializeRamen(string name, List<IngredientData> ingredients)
    {
        bowlName = name;
        Ingredients = ingredients;
        RamenProfile();
    }

    public void AddIngredient(IngredientData ingredient)
    {
        Ingredients.Add(ingredient);
    }
    public void RamenProfile()
    {
        for (int i = 0; i < Ingredients.Count; i++)
        {
            this.rich = Mathf.Min(this.rich + Ingredients[i].Rich, 10f);
            this.spicy = Mathf.Min(this.spicy + Ingredients[i].Spicy, 10f);
            this.meaty = Mathf.Min(this.meaty + Ingredients[i].Meaty, 10f);
            this.fishy = Mathf.Min(this.fishy + Ingredients[i].Fishy, 10f);
            this.umami = Mathf.Min(this.umami + Ingredients[i].Umami, 10f);
         //   this.sweet = Mathf.Min(this.sweet + Ingredients[i].sweet, 10f);
         //   this.sour = Mathf.Min(this.sour + Ingredients[i].sour, 10f); 
            this.size = Mathf.Min(this.size + Ingredients[i].Size, 10f);
            this.presentation = Mathf.Min(this.presentation + Ingredients[i].Presentation, 5f);
            this.aroma = Mathf.Min(this.aroma + Ingredients[i].Aroma, 5f);
            this.quality = Mathf.Min(this.quality + Ingredients[i].Quality, 5f);
            //this.timeToCook = this.timeToCook + Ingredients[i].timeToCook;

        }
        //this.bowlName = name;
    }
}
