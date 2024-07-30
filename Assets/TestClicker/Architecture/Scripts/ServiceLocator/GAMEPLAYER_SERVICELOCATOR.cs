using UnityEngine;

public class GAMEPLAYER_SERVICELOCATOR : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private Coins _coins;
    private void Awake()
    {
        ServiceLocator serviceLocator = new ServiceLocator();

        ServiceLocator.Current.Register<GameManager>(gameManager);

        _coins = new Coins();
        ServiceLocator.Current.Register<Coins>(_coins);
    }
}
