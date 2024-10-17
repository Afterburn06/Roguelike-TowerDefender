using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // New Game Button
    public void NewGame()
    {
        SceneManager.LoadScene("IngameMenu");
    }
}
