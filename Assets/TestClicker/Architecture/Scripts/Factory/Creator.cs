using System.Collections.Generic;
using UnityEngine;

public abstract class Creator
{
    public abstract List<CoinBehaviur> CreateCoin(Transform parent, int count);
}
