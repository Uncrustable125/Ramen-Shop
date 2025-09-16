
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] PersonManager personManager;

    void Start()
    {
        personManager.StartGame();

    }
}