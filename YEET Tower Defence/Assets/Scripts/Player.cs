using UnityEngine;

public class Player : MonoBehaviour
{
    public string ID;
    public int Money;
    public int startMoney;
    public int startLives;
    public int Lives;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }

    public void ExtractLives()
    {
        Lives--;
    }
}
