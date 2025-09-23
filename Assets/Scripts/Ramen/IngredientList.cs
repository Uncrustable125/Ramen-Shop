using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;

public class IngredientList
{
    private static IngredientList ingredientList;
    private static List<IngredientData> all = new List<IngredientData>();

    public static bool IsLoaded { get; private set; } = false;
    public static event Action OnIngredientsLoaded;

    public static List<IngredientData> All() 
    {
        return all;
    }

    public static async Task InitializeAsync()
    {
        if (IsLoaded) return;
        await LoadAllIngredientsAsync();
        OnIngredientsLoaded?.Invoke();
    }


    /// <summary>
    /// Pick a random ingredient. Returns null if not loaded yet.
    /// </summary>
    /*
    public static Ingredient PickRandomIngredient()
    {
        List<Ingredient> list = new List<Ingredient>();

        if (!IsLoaded || all.Count == 0) return null;
        int index = UnityEngine.Random.Range(0, all.Count);
        return all[index];
    }
    */
    /// <summary>
    /// Asynchronously loads all Ingredients via Addressables.
    /// </summary>
    private static async Task LoadAllIngredientsAsync()
    {
        all.Clear();

        // Load all ingredients labeled "Ingredients"
        AsyncOperationHandle<IList<IngredientData>> handle =
            Addressables.LoadAssetsAsync<IngredientData>("IngredientDatas", null);

        await handle.Task; // Wait for all ingredients to load

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            all.AddRange(handle.Result);
            IsLoaded = true;
        }
        else
        {
            Debug.LogError("Failed to load IngredientDatas via Addressables.");
        }
    }
}
