using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int currentMoney;

    [Header("Starting Money Amount")]
    public int startingMoney;

    [Header("UI Elements")]
    public TextMeshProUGUI moneyText;

    void Start()
    {
        // Set the player's current money to the desired starting amount
        currentMoney = startingMoney;
    }

    void Update()
    {
        // Set the money text to the current amount of money the player has
        moneyText.text = currentMoney.ToString();
    }
}
