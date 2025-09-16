using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class RamenStand : MonoBehaviour
{
    public List<Ramen> ramenMenu = new List<Ramen>();
    int ramenOrdered0, ramenOrdered1, ramenOrdered2;

    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            Ramen ramen = IngredientDatabase.
                Instance.GenerateRandomRamenBowl();
            ramenMenu.Add(ramen);
        }
        
    }

    public bool OrderingRamen(Person person)
    {
        float preference = 0;
        int bestRamen = 0;
        for (int i = 0; i < ramenMenu.Count; i++)
        {         
            if (preference < person.RamenPreference(ramenMenu[i]))
            {
                preference = person.RamenPreference(ramenMenu[i]);
                bestRamen = i;
            }
        }

        if (preference < 3.0f)
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
}
