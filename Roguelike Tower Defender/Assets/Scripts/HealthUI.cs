using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image fill;
    public TextMeshProUGUI healthText;
    public PlayerStats stats;

    void Update()
    {
        healthText.text = "Health: " + PlayerStats.playerHealth + "/" + stats.playerStartHealth;
        fill.fillAmount = (float)PlayerStats.playerHealth / (float)stats.playerStartHealth;
    }
}
