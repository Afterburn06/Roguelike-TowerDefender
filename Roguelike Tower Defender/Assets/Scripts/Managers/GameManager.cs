using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;

    void Start()
    {
        // Reset the gameOver variable
        gameOver = false;
    }

    void Update()
    {
        // If the player's health reaches zero
        if (PlayerStats.playerHealth == 0)
        {
            Debug.Log("Game Over");
            // Set the gameOver variable to true
            gameOver = true;
        }
    }
}