using System;

public interface IUpgratbleIncome 
{
    public event Action<int, int> OnUpgradeLevelChanged;
    void Upgrade();
    int GetPrice();
    int GetLvl();
    void Start();
}
