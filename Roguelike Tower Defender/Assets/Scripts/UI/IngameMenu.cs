using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour
{
    public PlayerStats stats;

    public GameObject basic;
    public GameObject sniper;
    public GameObject slugger;
    public GameObject spitter;
    public GameObject farm;

    void Awake()
    {
        basic.GetComponent<Turret>().tier = PlayerStats.basicTier;
        sniper.GetComponent<Turret>().tier = PlayerStats.sniperTier;
        slugger.GetComponent<Turret>().tier = PlayerStats.sluggerTier;
        spitter.GetComponent<Turret>().tier = PlayerStats.spitterTier;
        farm.GetComponent<Turret>().tier = PlayerStats.farmTier;
    }

    // Start Level Button
    public void StartLevel()
    {
        // Load the level
        SceneManager.LoadScene("Level");
    }

    public void Save()
    {
        SaveSystem.SavePlayer(stats);
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
