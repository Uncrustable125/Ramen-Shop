using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Bootstrap : MonoBehaviour
{
    private async void Start()
    {
        // Initialize Addressables first
        await UnityEngine.AddressableAssets.Addressables.InitializeAsync().Task;

        // Initialize your static lists
        await TownDataList.InitializeAsync();
        await PersonDataList.InitializeAsync();
        await IngredientList.InitializeAsync();
        RNG.Init();
        Debug.Log("All addressable data loaded!");

        // Now load the real game scene
        SceneManager.LoadScene("RAMENTIME");
    }
}
