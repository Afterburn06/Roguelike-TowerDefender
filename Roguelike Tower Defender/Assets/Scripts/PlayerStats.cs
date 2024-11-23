using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float playerHealth;

    [Header("Starting Player Health")]
    public float playerStartHealth;

    [Header("Storage")]
    public static int basicTier;
    public static int sniperTier;
    public static int sluggerTier;
    public static int spitterTier;
    public static int farmTier;
    public static int materialOneAmount;
    public static int materialTwoAmount;
    public static bool sluggerUnlocked;
    public static bool spitterUnlocked;
    public static bool farmUnlocked;
    public static int equippedTurretOne;
    public static int equippedTurretTwo;
    public static int equippedTurretThree;
    public static int equippedTurretFour;
    public static int equippedTurretFive;

    void Start()
    {
        // Set the player's current health to the starting amount
        playerHealth = playerStartHealth;
    }
}
