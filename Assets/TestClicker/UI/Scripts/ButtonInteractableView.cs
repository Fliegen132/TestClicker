using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractableView : MonoBehaviour
{
    [SerializeField] private Button clickButton;
    [SerializeField] private Button passiveButton;

    private IUpgratbleIncome _passiveIncome;
    private IUpgratbleIncome _clickIncome;
    private GameManager _gameManager;

    private Coins _coins;
    private void Start()
    {
        _coins = ServiceLocator.Current.Get<Coins>();
        _gameManager = ServiceLocator.Current.Get<GameManager>();

        _coins.OnCoinsChanged += UpgradeBtns;
        _passiveIncome = (IUpgratbleIncome)_gameManager.GetIncomeManager().GetIncome<PassiveIncome>();
        _clickIncome = (IUpgratbleIncome)_gameManager.GetIncomeManager().GetIncome<ClickIncome>();

        UpgradeBtns(_coins.GetCount());
    }

    private void UpgradeBtns(int coins)
    {
        if (coins >= _passiveIncome.GetPrice())
            passiveButton.interactable = true;
        else 
            passiveButton.interactable = false;

        if (coins >= _clickIncome.GetPrice())
            clickButton.interactable = true;
        else
            clickButton.interactable = false;
    }
}
