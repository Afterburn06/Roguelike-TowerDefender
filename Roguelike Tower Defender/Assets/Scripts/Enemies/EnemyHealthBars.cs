using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBars : MonoBehaviour
{
    private Image healthBar;
    private Enemy enemy;

    void Start()
    {
        // Get the healthbar image and Enemy script
        healthBar = GetComponent<Image>();
        enemy = GetComponentInParent<Enemy>();
    }

    void Update()
    {
        // Change health bar fill
        healthBar.fillAmount = enemy.currentHealth / enemy.startHealth;
    }
}
