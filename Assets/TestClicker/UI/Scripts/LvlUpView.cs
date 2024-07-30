using TMPro;
using UnityEngine;

public class LvlUpView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI passiveLvlText;
    [SerializeField] private TextMeshProUGUI clickLvlText;
    [SerializeField] private TextMeshProUGUI clickPriceText;
    [SerializeField] private TextMeshProUGUI passivePriceText;

    [SerializeField] private TextMeshProUGUI clickText;

    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = ServiceLocator.Current.Get<GameManager>();
        IUpgratbleIncome passiveUp = (IUpgratbleIncome)_gameManager.GetIncomeManager().GetIncome<PassiveIncome>();
        IUpgratbleIncome clickUp = (IUpgratbleIncome)_gameManager.GetIncomeManager().GetIncome<ClickIncome>();
        passiveUp.OnUpgradeLevelChanged += UpgradePassiveText;
        clickUp.OnUpgradeLevelChanged += UpgradeClicktext;
        passiveUp.Start();
        clickUp.Start();
    }

    public void UpgradePassiveText(int price, int lvl)
    {
        passiveLvlText.text = $"LV {lvl}";
        passivePriceText.text = $"PASSIVE {price}";
    }

    public void UpgradeClicktext(int price, int lvl)
    {
        clickLvlText.text = $"LV {lvl}";
        clickPriceText.text = $"CLICK {price}";
        clickText.text = $"+{_gameManager.GetIncomeManager().GetIncome<ClickIncome>().GetIncome()}";
    }
}
