using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour
{
    // Start Level Button
    public void StartLevel()
    {
        // Load the level
        SceneManager.LoadScene("Level");
    }

    // Inventory Button
    public void Inventory()
    {
        // Load the inventory
        SceneManager.LoadScene("Inventory");
    }

    // Menu Button
    public void Menu()
    {
        // Load the main menu
        SceneManager.LoadScene("MainMenu");
    }
}
