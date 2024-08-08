using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int playerHealth;
    public int playerStartHealth;

    void Start()
    {
        playerHealth = playerStartHealth;
    }
}
