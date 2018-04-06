using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;
    public Player player;
	void Update ()
    {
        moneyText.text = "$" + player.Money.ToString();
	}
}
