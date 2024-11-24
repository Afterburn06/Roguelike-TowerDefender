using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameMenu : MonoBehaviour
{
    [Header("Turrets")]
    public GameObject basic;
    public GameObject sniper;
    public GameObject slugger;
    public GameObject spitter;
    public GameObject farm;

    [Header("UI")]
    public GameObject confirmUI;
    public GameObject controlsUI;

    [Header("Buttons")]
    public Button startButton;
    public Button saveButton;
    public Button inventoryButton;
    public Button controlsButton;
    public Button mainMenuButton;

    [Header("Other")]
    public TextMeshProUGUI saveText;
    public PlayerStats stats;

    void Awake()
    {
        // Get the turret tiers from the PlayerStats script
        basic.GetComponent<Turret>().tier = PlayerStats.basicTier;
        sniper.GetComponent<Turret>().tier = PlayerStats.sniperTier;
        slugger.GetComponent<Turret>().tier = PlayerStats.sluggerTier;
        spitter.GetComponent<Turret>().tier = PlayerStats.spitterTier;
        farm.GetComponent<Turret>().tier = PlayerStats.farmTier;
    }

    private void Start()
    {
        // Disable UI
        confirmUI.SetActive(false);
        controlsUI.SetActive(false);
    }

    // Start Level Button
    public void StartLevel()
    {
        // Load the level
        SceneManager.LoadScene("Level");
    }

    public void Save()
    {
        // Save the game
        SaveSystem.SavePlayer(stats);

        // Change the save text
        StartCoroutine(ChangeSaveText());
    }

    IEnumerator ChangeSaveText()
    {
        // Change save text
        saveText.text = "Saved!";

        // Wait
        yield return new WaitForSeconds(1.5f);

        // Change it back
        saveText.text = "Save";
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
        // Enable UI
        confirmUI.SetActive(true);
        // Disable buttons
        startButton.interactable = false;
        saveButton.interactable = false;
        inventoryButton.interactable = false;
        controlsButton.interactable = false;
        mainMenuButton.interactable = false;
    }

    public void No()
    {
        // Disable UI
        confirmUI.SetActive(false);
        // Enable Buttons
        startButton.interactable = true;
        saveButton.interactable = true;
        inventoryButton.interactable = true;
        controlsButton.interactable = true;
        mainMenuButton.interactable = true;
    }

    public void Yes()
    {
        // Load the main menu
        SceneManager.LoadScene("MainMenu");
    }

    public void Controls()
    {
        // Enable UI
        controlsUI.SetActive(true);
        // Disable buttons
        startButton.interactable = false;
        saveButton.interactable = false;
        inventoryButton.interactable = false;
        controlsButton.interactable = false;
        mainMenuButton.interactable = false;
    }

    public void Close()
    {
        // Disable UI
        controlsUI.SetActive(false);
        // Enable buttons
        startButton.interactable = true;
        saveButton.interactable = true;
        inventoryButton.interactable = true;
        controlsButton.interactable = true;
        mainMenuButton.interactable = true;
    }
}
