using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;

public class TownDataList
{
    private static TownDataList peopleList;
    private static List<TownData> all = new List<TownData>();

    public static bool IsLoaded { get; private set; } = false;
    public static event Action OnPeopleLoaded;

    public static List<TownData> All()
    {
        return all;
    }

    public static async Task InitializeAsync()
    {
        if (IsLoaded) return;
        await LoadAllPersonDatasAsync();
        OnPeopleLoaded?.Invoke();
    }

    private static async Task LoadAllPersonDatasAsync()
    {
        all.Clear();

        // Load all ingredients labeled "Ingredients"
        AsyncOperationHandle<IList<TownData>> handle =
            Addressables.LoadAssetsAsync<TownData>("TownDatas", null);

        await handle.Task; // Wait for all ingredients to load

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            all.AddRange(handle.Result);
            IsLoaded = true;
        }
        else
        {
            Debug.LogError("Failed to load TownDatas via Addressables.");
        }
    }
    public static TownData GetTown(TownName townName)
    {
        foreach (TownData town in all)
        {
            if (town.TownName == townName)
            {
                return town;
            }
        }
        Debug.LogError($"Town {townName} not found!");
        return null;
    }
}
