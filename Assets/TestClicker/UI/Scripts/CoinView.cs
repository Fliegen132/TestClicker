using TMPro;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;

    private void Start()
    {
        ServiceLocator.Current.Get<Coins>().OnCoinsChanged += UpgradeText;
        UpgradeText(ServiceLocator.Current.Get<Coins>().GetCount());
    }

    private void UpgradeText(int amount)
    {
        coinsText.text = $"{amount}";
    }
}
