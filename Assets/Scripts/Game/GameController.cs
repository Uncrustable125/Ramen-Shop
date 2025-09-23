
using UnityEngine;
using System.Threading.Tasks;

public enum DifficultyLevel { VeryEasy = -2, Easy = -1, Normal = 0, Difficult = 1 }
public enum TownName { Tokyo, Kyoto, Osaka, Sapporo, Nagoya, Fukuoka }

public class GameController : MonoBehaviour
{
    public static GameController Instance; 
    [SerializeField] PersonManager personManager;
    [SerializeField] Town town;
    [SerializeField] TownName townName;
    
    [SerializeField] DifficultyLevel difficulty;
    public DifficultyLevel Difficulty => difficulty;
    public TownName TownName => townName;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        personManager.StartGame();
    }

}
