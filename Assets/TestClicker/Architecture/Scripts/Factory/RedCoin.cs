using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoin : Creator
{
    private Color _color = new Color(255, 0, 0);
    public override List<CoinBehaviur> CreateCoin(Transform parent, int count)
    {
        List<CoinBehaviur> coinBehaviurs = new List<CoinBehaviur>();

        for (int i = 0; i < count; i++)
        {
            GameObject go = Resources.Load<GameObject>("Coin");
            go.GetComponent<SpriteRenderer>().color = _color;
            CoinBehaviur coin = Object.Instantiate(go, parent).AddComponent<CoinBehaviur>();
            coinBehaviurs.Add(coin);
            go.SetActive(false);
        }
        return coinBehaviurs;
    }
}
