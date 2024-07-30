using System;
using UnityEngine;

public class Coins : IService
{
    private int _coins;
    public event Action<int> OnCoinsChanged;

    public void AddCoins(int amount)
    {
        _coins += amount;
        OnCoinsChanged?.Invoke(_coins);
    }

    public bool RemoveCoins(int amount)
    {
        if (_coins >= amount)
        {
            _coins -= amount;
            OnCoinsChanged?.Invoke(_coins);
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetCount() => _coins;
}
