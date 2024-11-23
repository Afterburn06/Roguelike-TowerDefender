using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameMenu : MonoBehaviour
{
    public PlayerStats stats;

    public GameObject basic;
    public GameObject sniper;
    public GameObject slugger;
    public GameObject spitter;
    public GameObject farm;

    public GameObject confirmUI;

    void Awake()
    {
        basic.GetComponent<Turret>().tier = PlayerStats.basicTier;
        sniper.GetComponent<Turret>().tier = PlayerStats.sniperTier;
        slugger.GetComponent<Turret>().tier = PlayerStats.sluggerTier;
        spitter.GetComponent<Turret>().tier = PlayerStats.spitterTier;
        farm.GetComponent<Turret>().tier = PlayerStats.farmTier;
    }

    private void Start()
    {
        confirmUI.SetActive(false);
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
        confirmUI.SetActive(true);
    }

    public void No()
    {
        confirmUI.SetActive(false);
    }

    public void Yes()
    {
        // Load the main menu
        SceneManager.LoadScene("MainMenu");
    }
}
