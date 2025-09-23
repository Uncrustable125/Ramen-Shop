using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderKeywordFilter.FilterAttribute;

public class Person : MonoBehaviour
{
    PersonData personData;
    public bool canMoveToNextWaypoint, didNotOrder;
    public float preference;
    SpriteRenderer spriteRenderer;
    public  PersonData PersonData => personData;
    void Awake()
    {
        didNotOrder = false;
    }
    public void InitPerson(PersonData personData)
    {
        this.personData = personData;
        this.preference = 0f;
    }
    /* public void CreateAttributes(PersonData personData)
     {
         this.richPreference = personData.richPreference;
         this.spicyPreference = personData.spicyPreference;
         this.meatyPreference = personData.meatyPreference;  
         this.fishyPreference = personData.fishyPreference;
         this.umamiPreference = personData.umamiPreference;
         this.hunger = personData.hunger;
         this.sourPreference = personData.sourPreference;
         this.sweetPreference = personData.sweetPreference;
         this.difficulty = personData.difficulty;
         this.Likes = personData.Likes;
         this.Loves = personData.Loves;
         this.Dislikes = personData.Dislikes;

     }*/
    public int SayRamenOpinion()
    {

        if (preference >= 9.2)
        {
            Debug.Log("やばい! Yabai!");
            return 0;
        }
        else if (preference >= 7)
        {
            Debug.Log("美味しい! Oishii!");
            return 1;
        }
        else if (preference >= 5)
        {
            Debug.Log("旨い! Umai!");
            return 2;
        }
        else if (preference >= 2)
        {
            Debug.Log("えええええ Ehhhhhhh");
            return 3;
        }
        else
        {
            Debug.Log("まずい mazui");
            return 4;

        }
    
    }
}


