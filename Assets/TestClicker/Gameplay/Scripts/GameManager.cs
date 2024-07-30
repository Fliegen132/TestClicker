using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IService
{
    [SerializeField] private DifficultySettings difficultySettings;
    [SerializeField] private Button incomeButton;
    [SerializeField] private Button passiveUpgradeButton;
    [SerializeField] private Button clickUpgradeButton;
    [SerializeField] private Transform coinParent;

    private List<CoinBehaviur> _coinsList;
    private Coins _coins;
    private IncomeManager _incomeManager;

    private Creator _creator;

    private Vector3 _mousePos => Input.mousePosition;
    private void Awake()
    {
        _creator = new GreenCoin();
        _coinsList = _creator.CreateCoin(coinParent, 70);
        _incomeManager = new IncomeManager(difficultySettings);
    }

    private void Start()
    {
        _coins = ServiceLocator.Current.Get<Coins>();   
        Init();
    }

    private void Update()
    {
        _coins.AddCoins(_incomeManager.GetIncome<PassiveIncome>().GetIncome());
    }

    private void Init()
    {
        incomeButton.onClick.AddListener(delegate
        {
            _coins.AddCoins(_incomeManager.GetIncome<ClickIncome>().GetIncome());
            foreach (var coin in _coinsList)
            { 
                if(!coin.gameObject.activeInHierarchy)
                {
                    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(_mousePos.x,
                        _mousePos.y, Camera.main.nearClipPlane));
                    mouseWorldPos.z = 0; 
                    coin.gameObject.SetActive(true);
                    coin.gameObject.transform.position = mouseWorldPos;
                    coin.AddForce();
                    break;
                }
            }
        });

        passiveUpgradeButton.onClick.AddListener(delegate
        {
            IUpgratbleIncome upgrade = (IUpgratbleIncome)_incomeManager.GetIncome<PassiveIncome>();
            upgrade.Upgrade();
        });

        clickUpgradeButton.onClick.AddListener(delegate
        {
            IUpgratbleIncome upgrade = (IUpgratbleIncome)_incomeManager.GetIncome<ClickIncome>();
            upgrade.Upgrade();
        });

    }

    public IncomeManager GetIncomeManager() => _incomeManager;
}
