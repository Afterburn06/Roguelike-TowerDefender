using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBars : MonoBehaviour
{
    private Image healthBar;
    private Enemy enemy;

    void Start()
    {
        healthBar = GetComponent<Image>();
        enemy = GetComponentInParent<Enemy>();
    }

    void Update()
    {
        healthBar.fillAmount = enemy.currentHealth / enemy.startHealth;
    }
}
