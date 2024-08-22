using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int playerHealth;
    public int playerStartHealth;

    public static int money;
    public int startingMoney;

    void Start()
    {
        playerHealth = playerStartHealth;
        money = startingMoney;
    }
}
