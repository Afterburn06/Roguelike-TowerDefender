using System.Collections;
using TMPro;
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
    public GameObject controlsUI;
    
    public Button startButton;
    public Button saveButton;
    public Button inventoryButton;
    public Button controlsButton;
    public Button mainMenuButton;

    public TextMeshProUGUI saveText;

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
        SaveSystem.SavePlayer(stats);

        StartCoroutine(ChangeSaveText());
    }

    IEnumerator ChangeSaveText()
    {
        saveText.text = "Saved!";

        yield return new WaitForSeconds(2);

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
        confirmUI.SetActive(true);
        startButton.interactable = false;
        saveButton.interactable = false;
        inventoryButton.interactable = false;
        controlsButton.interactable = false;
        mainMenuButton.interactable = false;
    }

    public void No()
    {
        confirmUI.SetActive(false);
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
        controlsUI.SetActive(true);
        startButton.interactable = false;
        saveButton.interactable = false;
        inventoryButton.interactable = false;
        controlsButton.interactable = false;
        mainMenuButton.interactable = false;
    }

    public void Close()
    {
        controlsUI.SetActive(false);
        startButton.interactable = true;
        saveButton.interactable = true;
        inventoryButton.interactable = true;
        controlsButton.interactable = true;
        mainMenuButton.interactable = true;
    }
}
