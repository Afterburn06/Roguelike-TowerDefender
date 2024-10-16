using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void Inventory()
    {
        SceneManager.LoadScene("Inventory");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
