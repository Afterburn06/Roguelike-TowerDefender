using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [Header("UI Elements")]
    public Image fill;
    public TextMeshProUGUI healthText;

    [Header("Player Stats")]
    public PlayerStats stats;

    void Update()
    {
        // Set the health text to the amount of current health out of the total player health
        healthText.text = "Health: " + PlayerStats.playerHealth + "/" + stats.playerStartHealth;
        // Set the health slider amount
        fill.fillAmount = PlayerStats.playerHealth / stats.playerStartHealth;
    }
}
