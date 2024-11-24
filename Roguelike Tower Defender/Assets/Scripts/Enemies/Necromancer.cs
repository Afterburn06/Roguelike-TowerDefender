using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Necromancer : Enemy
{
    public float spawnRate;
    public GameObject zombie;
    public GameObject vampire;
    public GameObject skeleton;
    public GameObject ghost;

    public GameObject necromancerUI;
    public Image necromancerHealthBar;
    public TextMeshProUGUI necromancerHealthText;

    public static bool necromancerDead;

    public override void Start()
    {
        base.Start();

        necromancerDead = false;

        InvokeRepeating("SpawnAllies", 5f, spawnRate);
    }

    protected override void Update()
    {
        // If the enemy has no health or the game is over
        if (currentHealth <= 0f || GameManager.gameOver)
        {
            necromancerDead = true;
            Die();
        }
        else
        {
            necromancerHealthBar.fillAmount = currentHealth / startHealth;
            necromancerHealthText.text = "Necromancer: " + currentHealth + " / " + startHealth;
        } 
    }

    void SpawnAllies()
    {
        int alliesToSpawn = Random.Range(1, 6);

        for (int i = 0; i < alliesToSpawn; i++)
        {
            int allyTypeToSpawn = Random.Range(1, 5);

            if (allyTypeToSpawn == 1)
            {
                Spawn(zombie);
            }
            else if (allyTypeToSpawn == 2)
            {
                Spawn(vampire);
            }
            else if (allyTypeToSpawn == 3)
            {
                Spawn(skeleton);
            }
            else if (allyTypeToSpawn == 4)
            {
                Spawn(ghost);
            }
        }
    }

    void Spawn(GameObject objectToSpawn)
    {
        Vector3 spawnOffset = new Vector3(0, 0, 1);

        Instantiate(objectToSpawn, transform.position + spawnOffset, Quaternion.identity);
    }

    public void SetHealthUI(GameObject ui, Image image, TextMeshProUGUI text)
    {
        ui.SetActive(true);

        necromancerUI = ui;
        necromancerHealthBar = image;
        necromancerHealthText = text;
    }
}
