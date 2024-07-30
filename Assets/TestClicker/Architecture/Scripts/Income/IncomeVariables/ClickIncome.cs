using System;

public class ClickIncome : IIncomeStrategy, IUpgratbleIncome
{
    public event Action<int, int> OnUpgradeLevelChanged;
    private DifficultySettings difficultySettings;
    private int _price;
    private int _lvl;
    private int _income;
    

    public ClickIncome(DifficultySettings settings)
    {
        difficultySettings = settings;
        _price = difficultySettings.StartPrice;
        _income = difficultySettings.StartIncome;
    }

    public void Start()
    {
        OnUpgradeLevelChanged?.Invoke(_price, _lvl);
    }

    public void Upgrade()
    {
        if (ServiceLocator.Current.Get<Coins>().RemoveCoins(_price))
        {
            _price *= difficultySettings.MultiplyPrice;
            _income *= difficultySettings.MultiplyIncome;
            _lvl++;
            OnUpgradeLevelChanged?.Invoke(_price, _lvl);
        }
    }

    public int GetLvl() => _lvl;
    public int GetIncome() => _income;
    public int GetPrice() => _price;
}
