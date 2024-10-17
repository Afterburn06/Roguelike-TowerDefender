using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float playerHealth;

    [Header("Starting Player Health")]
    public float playerStartHealth;

    void Start()
    {
        // Set the player's current health to the starting amount
        playerHealth = playerStartHealth;
    }
}
