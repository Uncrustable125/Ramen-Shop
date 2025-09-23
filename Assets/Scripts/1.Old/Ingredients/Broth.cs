using UnityEngine;
//[CreateAssetMenu(fileName = "NewIngredient", menuName = "Ingredient/Broth")]

public class Broth : IngredientData
{
    public Broth()
    {

    }
    /*
    public void AddToBroth(Ingredient ingredient)
    {
        rich += (ingredient.rich / water);
        spicy += (ingredient.spicy / water);
        meaty += (ingredient.meaty / water);
        fishy += (ingredient.fishy / water);
        umami += (ingredient.umami / water);
        sweet += (ingredient.sweet / water);
        sour += (ingredient.sour / water);
        RecalculateBrothConcentration(ingredient.water);
    }

    void RecalculateBrothConcentration(float addedWater)
    {
        //C'=(C*W)/(W+W')
        water += addedWater;
        rich = (rich*water) / (water);
        spicy = (spicy * water) / (water);
        meaty = (meaty * water) / (water);
        fishy = (fishy * water) / (water);
        umami = (umami * water) / (water);
        sweet = (sweet * water) / (water);
        sour = (sour * water) / (water);

    }*/
}
