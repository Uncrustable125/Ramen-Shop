using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderKeywordFilter.FilterAttribute;

public class Person : MonoBehaviour
{
    [Range(0f, 1f)] public float richPreference;
    [Range(0f, 1f)] public float spicyPreference;
    [Range(0f, 1f)] public float meatyPreference;
    [Range(0f, 1f)] public float fishyPreference;
    [Range(0f, 1f)] public float umamiPreference;
    [Range(0f, 1f)] public float hunger;
    [Range(0f, 1f)] public float sourPreference;
    [Range(0f, 1f)] public float sweetPreference;

    public float difficulty;


    public List<Ingredient> Likes = new List<Ingredient>();
    public List<Ingredient> Loves = new List<Ingredient>();
    public List<Ingredient> Dislikes = new List<Ingredient>();
    RamenOpinion ramenOpinion;
    public bool canMoveToNextWaypoint, didNotOrder;

    public enum RamenOpinion { NoGood, Ehhhhhhh, Oishii, Yabai }


    //do I need?
    public Guid uniqueID;

    void Awake()
    {
        difficulty = PersonManager.Instance.difficulty;
        didNotOrder = false;
        GenerateUniqueID();
        GenerateRandom();

    }

    public void GenerateUniqueID()
    {
        uniqueID = System.Guid.NewGuid();
    }
    // Generate random customer with minor variance
    public void GenerateRandom()
    {
        richPreference = UnityEngine.Random.Range(1f, 10f);
        spicyPreference = UnityEngine.Random.Range(1f, 10f);
        meatyPreference = UnityEngine.Random.Range(1f, 10f);
        fishyPreference = UnityEngine.Random.Range(1f, 10f);
        umamiPreference = UnityEngine.Random.Range(1f, 10f);
        sweetPreference = UnityEngine.Random.Range(1f, 10f);
        sourPreference = UnityEngine.Random.Range(1f, 10f);
        hunger = UnityEngine.Random.Range(1f, 10f);

        Likes.Add(PersonManager.Instance.GenerateRandomIngredient());
        Loves.Add(PersonManager.Instance.GenerateRandomIngredient());
        Dislikes.Add(PersonManager.Instance.GenerateRandomIngredient());
    }






    // Calculate how well the customer likes a given ramen
    public float RamenPreference(Ramen ramen)
    {
        // Sum of matches between customer preferences and bowl flavor profile
        float ramenScore = 0f;
        ramenScore += Mathf.Abs(richPreference - ramen.rich);
        ramenScore += Mathf.Abs(spicyPreference - ramen.spicy);
        ramenScore += Mathf.Abs(meatyPreference - ramen.meaty);
        ramenScore += Mathf.Abs(fishyPreference - ramen.fishy);
        ramenScore += Mathf.Abs(umamiPreference - ramen.umami);
        ramenScore += Mathf.Abs(sweetPreference - ramen.sweet);
        ramenScore += Mathf.Abs(sourPreference - ramen.sour);
        ramenScore += Mathf.Abs(hunger - ramen.size);


        //How do I want to factor in quality?
        //Should quality only add or should it be a minimum requirement?
        //ramenScore += Mathf.Abs(ramen.Quality);


        // Normalize by total number of flavor profiles
        ramenScore = ramenScore / 8f;

        foreach (Ingredient ingredient in ramen.Ingredients)
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
        }

        ramenScore += ramen.presentation;
        ramenScore += ramen.quality;
        ramenScore -= difficulty;

        return SetRamenOpinion(Mathf.Clamp(ramenScore, 0f, 10f));
    }
    float SetRamenOpinion(float score)
    {
        if (score >= 8.5)
        {
            ramenOpinion = RamenOpinion.Yabai;

        }
        else if (score >= 5)
        {
            ramenOpinion = RamenOpinion.Oishii;

        }
        else if (score >= 2.5)
        {
            ramenOpinion = RamenOpinion.Ehhhhhhh;
        }
        else
        {
            ramenOpinion = RamenOpinion.NoGood;
        }
        return score;
    }
    public void SayRamenOpinion()
    {

        if (ramenOpinion == RamenOpinion.Yabai)
        {
            Debug.Log("やばい! Yabai!");
        }
        if (ramenOpinion == RamenOpinion.Oishii)
        {
            if (UnityEngine.Random.value < 0.5f)
            {
                Debug.Log("美味しい! Oishii!");
            }
            else
            {
                Debug.Log("旨い! Umai!");
            }
        }
        else if (ramenOpinion == RamenOpinion.Ehhhhhhh)
        {
            Debug.Log("えええええ Ehhhhhhh");
        }
        else
        {
            Debug.Log("まずい mazui");

        }
    
    }
}


