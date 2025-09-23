using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;

public class RamenStand : MonoBehaviour
{
    public static RamenStand Instance;
    public Ramen ramen;
    List<Ramen> ramenMenu = new List<Ramen>();
    float difficultyMod = 0f;
    int ramenOrdered0, ramenOrdered1, ramenOrdered2;
    float  preferenceMod;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        ramen = gameObject.AddComponent<Ramen>();
    }

    private void Start()
    {
        difficultyMod = (float)GameController.Instance.Difficulty 
            / 2 + Town.Instance.TownData.AddedDifficulty;
    }
    public void MakeRamen()
    {
        ramen.InitializeRamen("Ramen Bowl", IngredientList.All());
        ramenMenu.Add(ramen);
    }
    public bool OrderingRamen(Person person)
    {
        person.preference = 0;
        int bestRamen = 0;
        for (int i = 0; i < ramenMenu.Count; i++)
        {
            float x = RamenPreference(ramenMenu[i], person);
            if (person.preference < x)
            {
                person.preference = x;
                bestRamen = i;
            }
        }

        if (person.preference < 3.0f)
        {
            Debug.Log("Customer did not order ramen");
            return false;
        }
        if (bestRamen == 0)
        {
            ramenOrdered0++;
        }
        else if (bestRamen == 1)
        {
            ramenOrdered1++;
        }
        else if (bestRamen == 2)
        {
            ramenOrdered2++;
        }
        return true;
    }


    void VariabilityOfPrefAndTol()
    {
        //This gives even chance for preferences to be +1 or -1
        //With a difficulty modifier adding as well
        //Will need balance       
        preferenceMod = RNG.NextFloat()/100;
        if (RNG.NextBool())
        {
            preferenceMod = -preferenceMod;
        }
        preferenceMod += difficultyMod;

    }

    public float RamenPreference(Ramen ramen, Person person)
    {
        float ramenScore = 0f;
        //Mathf limits how much score can be gained from one flavor - difficulty mod
        //Also limits how little someone can like 
        VariabilityOfPrefAndTol();
        ramenScore += Mathf.Clamp(
            ramen.rich - Mathf.Clamp(person.PersonData.RichPreference + preferenceMod, 0, 10),
            -1f - difficultyMod,
            2f - difficultyMod);

        VariabilityOfPrefAndTol();
        ramenScore += Mathf.Clamp(
            ramen.spicy - Mathf.Clamp(person.PersonData.SpicyPreference + preferenceMod, 0, 10),
            -1f - difficultyMod,
            2f - difficultyMod);

        VariabilityOfPrefAndTol();
        ramenScore += Mathf.Clamp(
            ramen.meaty - Mathf.Clamp(person.PersonData.MeatyPreference + preferenceMod, 0, 10),
            -1f - difficultyMod,
            2f - difficultyMod);

        VariabilityOfPrefAndTol();
        ramenScore += Mathf.Clamp(
            ramen.fishy - Mathf.Clamp(person.PersonData.FishyPreference + preferenceMod, 0, 10),
            -1f - difficultyMod,
            2f - difficultyMod);

        VariabilityOfPrefAndTol();
        ramenScore += Mathf.Clamp(
            ramen.umami - Mathf.Clamp(person.PersonData.UmamiPreference + preferenceMod, 0, 10),
            -1f - difficultyMod,
            2f - difficultyMod);


        /*         VariabilityOfPreference();
        // if (Mathf.Abs(person.PersonData.sweetPreference - ramen.sweet) >= tolerance)
        // {
        //     ramenScore += Mathf.Abs(person.PersonData.sweetPreference - ramen.sweet) - tolerance;
        // }
        //         VariabilityOfPreference();

        // if (Mathf.Abs(person.PersonData.sourPreference - ramen.sour) >= tolerance)
        // {
        //     ramenScore += Mathf.Abs(person.PersonData.sourPreference - ramen.sour) - tolerance;
        // }
        //         VariabilityOfPreference();

        // if (Mathf.Abs(person.PersonData.hunger - ramen.size) >= tolerance)
        // {
        //     ramenScore += Mathf.Abs(person.PersonData.hunger - ramen.size) - tolerance;
        // }
        */
        //Likes and dislikes
        /*   foreach (Ingredient ingredient in ramen.Ingredients)
           {
               if (Loves.Contains(ingredient))
               {
                   ramenScore += 2f;
               }
               else if (Likes.Contains(ingredient))
               {
                   ramenScore += 1f; 
               }
               else if (Dislikes.Contains(ingredient))
               {
                   ramenScore = 0f;
                   // They wont eat something they dont like
               }
           }*/
        ramenScore = Mathf.Clamp(ramenScore, 0, 10);
        Debug.Log(ramenScore);
        return ramenScore;
    }

    /* public float RamenPreference(Ramen ramen, Person person)
     {
         float ramenScore = 0f;

         VariabilityOfPrefAndTol();
         if (Mathf.Abs((person.PersonData.RichPreference + preferenceMod) - ramen.rich) >= tolerance)
         {
             ramenScore += Mathf.Abs(person.PersonData.RichPreference - ramen.rich) - tolerance;
         }
         VariabilityOfPrefAndTol();
         if (Mathf.Abs(person.PersonData.SpicyPreference - ramen.spicy) >= tolerance)
         {
             ramenScore += Mathf.Abs(person.PersonData.SpicyPreference - ramen.spicy) - tolerance;
         }
         VariabilityOfPrefAndTol();
         if (Mathf.Abs(person.PersonData.MeatyPreference - ramen.meaty) >= tolerance)
         {
             ramenScore += Mathf.Abs(person.PersonData.MeatyPreference - ramen.meaty) - tolerance;
         }
         VariabilityOfPrefAndTol();
         if (Mathf.Abs(person.PersonData.FishyPreference - ramen.fishy) >= tolerance)
         {
             ramenScore += Mathf.Abs(person.PersonData.FishyPreference - ramen.fishy) - tolerance;
         }
         VariabilityOfPrefAndTol();
         if (Mathf.Abs(person.PersonData.UmamiPreference - ramen.umami) >= tolerance)
         {
             ramenScore += Mathf.Abs(person.PersonData.UmamiPreference - ramen.umami) - tolerance;
         }

         /*         VariabilityOfPreference();
         // if (Mathf.Abs(person.PersonData.sweetPreference - ramen.sweet) >= tolerance)
         // {
         //     ramenScore += Mathf.Abs(person.PersonData.sweetPreference - ramen.sweet) - tolerance;
         // }
         //         VariabilityOfPreference();

         // if (Mathf.Abs(person.PersonData.sourPreference - ramen.sour) >= tolerance)
         // {
         //     ramenScore += Mathf.Abs(person.PersonData.sourPreference - ramen.sour) - tolerance;
         // }
         //         VariabilityOfPreference();

         // if (Mathf.Abs(person.PersonData.hunger - ramen.size) >= tolerance)
         // {
         //     ramenScore += Mathf.Abs(person.PersonData.hunger - ramen.size) - tolerance;
         // }
         */

    // Normalize by number of active flavor profiles (currently 5)
    /////////////   ramenScore /= 5f;

    //Likes and dislikes
    /*   foreach (Ingredient ingredient in ramen.Ingredients)
       {
           if (Loves.Contains(ingredient))
           {
               ramenScore += 2f;
           }
           else if (Likes.Contains(ingredient))
           {
               ramenScore += 1f; 
           }
           else if (Dislikes.Contains(ingredient))
           {
               ramenScore = 0f;
               // They wont eat something they dont like
           }
       }*/
    ////////////    return ramenScore;
}
   /* public void GenerateRandom()
    {
        if (RNG.NextFloat() > (.4 + difficulty))
        {
            //NEED A LOCATION DATABASE THAT WILL HOLD ALL THE PRESETS
            //FOR EACH LOCATION AND FEED IT TO THE PERSON GENERATOR
            richPreference = UnityEngine.Random.Range(1f, 10f);
            spicyPreference = UnityEngine.Random.Range(1f, 10f);
            meatyPreference = UnityEngine.Random.Range(1f, 10f);
            fishyPreference = UnityEngine.Random.Range(1f, 10f);
            umamiPreference = UnityEngine.Random.Range(1f, 10f);
            sweetPreference = UnityEngine.Random.Range(1f, 10f);
            sourPreference = UnityEngine.Random.Range(1f, 10f);
            hunger = UnityEngine.Random.Range(1f, 10f);

            RNG.Shuffle(IngredientDatabase.All());
            Likes.Add(IngredientDatabase.All()[0]);
            Loves.Add(IngredientDatabase.All()[1]);
            Dislikes.Add(IngredientDatabase.All()[2]);
        }
        else
        {
            richPreference = UnityEngine.Random.Range(1f, 10f);
            spicyPreference = UnityEngine.Random.Range(1f, 10f);
            meatyPreference = UnityEngine.Random.Range(1f, 10f);
            fishyPreference = UnityEngine.Random.Range(1f, 10f);
            umamiPreference = UnityEngine.Random.Range(1f, 10f);
            sweetPreference = UnityEngine.Random.Range(1f, 10f);
            sourPreference = UnityEngine.Random.Range(1f, 10f);
            hunger = UnityEngine.Random.Range(1f, 10f);

            RNG.Shuffle(IngredientDatabase.All());
            Likes.Add(IngredientDatabase.All()[0]);
            Loves.Add(IngredientDatabase.All()[1]);
            Dislikes.Add(IngredientDatabase.All()[2]);
        }
    }*/
