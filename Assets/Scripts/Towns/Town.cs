using UnityEngine;


public class Town : MonoBehaviour
{
    public static Town Instance;
    TownData townData;
    public TownData TownData => townData;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        townData = TownDataList.GetTown(GameController.Instance.TownName);

    }

}

