using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;

public class PersonDataList
{
    private static PersonDataList peopleList;
    private static List<PersonData> all = new List<PersonData>();

    public static bool IsLoaded { get; private set; } = false;
    public static event Action OnPeopleLoaded;

    public static List<PersonData> All()
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
        AsyncOperationHandle<IList<PersonData>> handle =
            Addressables.LoadAssetsAsync<PersonData>("PersonDatas", null);

        await handle.Task; // Wait for all ingredients to load

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            all.AddRange(handle.Result);
            IsLoaded = true;
        }
        else
        {
            Debug.LogError("Failed to load PersonDatas via Addressables.");
        }
    }
}
