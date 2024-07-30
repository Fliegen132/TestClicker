using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinsParent;
    private const uint _coinCount = 80;

    private void Start()
    {
        GenerateCoins();
    }

    private void GenerateCoins()
    { 
        for (int i = 0; i < _coinCount; i++)
        { 
             
        }
    }
}
