using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;

    void Start()
    {
        gameOver = false;
    }

    void Update()
    {
        if(PlayerStats.playerHealth == 0)
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}