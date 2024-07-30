using System;

public class IncomeManager
{
    private IIncomeStrategy _clickIncome;
    private IIncomeStrategy _passiveIncome;
    public IncomeManager(DifficultySettings difficultySettings)
    {
        _clickIncome = new ClickIncome(difficultySettings);
        _passiveIncome = new PassiveIncome(difficultySettings);
    }

    public IIncomeStrategy GetIncome<T>() where T : IIncomeStrategy
    {
        if (typeof(T) == typeof(ClickIncome))
        {
            return _clickIncome;
        }
        else if (typeof(T) == typeof(PassiveIncome))
        { 
            return _passiveIncome;
        }
        throw new InvalidOperationException($"Неизвестный тип стратегии дохода: {typeof(T)}");
    }
}
