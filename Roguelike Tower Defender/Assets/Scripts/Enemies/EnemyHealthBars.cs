using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBars : MonoBehaviour
{
    private Image healthBar;
    private Enemy thisEnemy;

    void Start()
    {
        healthBar = GetComponent<Image>();
        thisEnemy = GetComponentInParent<Enemy>();
    }

    void Update()
    {
        healthBar.fillAmount = thisEnemy.currentHealth / thisEnemy.startHealth;
    }
}
