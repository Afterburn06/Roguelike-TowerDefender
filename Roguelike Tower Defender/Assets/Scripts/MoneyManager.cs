using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int currentMoney;
    public int startingMoney;

    public TextMeshProUGUI moneyText;

    void Start()
    {
        currentMoney = startingMoney;
    }

    void Update()
    {
        moneyText.text = "$" + currentMoney.ToString();
    }
}
