using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float playerHealth;
    public float playerStartHealth;

    void Start()
    {
        playerHealth = playerStartHealth;
    }
}
