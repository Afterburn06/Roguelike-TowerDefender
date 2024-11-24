using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Necromancer : Enemy
{
    [Header("Stats")]
    public static bool necromancerDead;
    public float spawnRate;

    [Header("Spawnable Enemies")]
    public GameObject zombie;
    public GameObject vampire;
    public GameObject skeleton;
    public GameObject ghost;

    [Header("UI Elements")]
    public GameObject necromancerUI;
    public Image necromancerHealthBar;
    public TextMeshProUGUI necromancerHealthText;


    public override void Start()
    {
        // Use base Enemy Start functionality
        base.Start();

        // The necromancer is not dead
        necromancerDead = false;

        // Spawn allies after 5 seconds and every bit of time after determined by spawnrate
        InvokeRepeating("SpawnAllies", 5f, spawnRate);
    }

    protected override void Update()
    {
        // Remove base Enemy Update functionality

        // If the necromancer has no health or the game is over
        if (currentHealth <= 0f || GameManager.gameOver)
        {
            // The necromancer is dead
            necromancerDead = true;
            Die();
        }
        else
        {
            // Change UI elements
            necromancerHealthBar.fillAmount = currentHealth / startHealth;
            necromancerHealthText.text = "Necromancer: " + currentHealth + " / " + startHealth;
        } 
    }

    void SpawnAllies()
    {
        // Choose a random number of allies to spawn
        int alliesToSpawn = Random.Range(1, 6);

        // For each ally to spawn
        for (int i = 0; i < alliesToSpawn; i++)
        {
            // Choose a random type
            int allyTypeToSpawn = Random.Range(1, 5);

            // Spawn an ally based on that type
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
        // Set the spawn offset
        Vector3 spawnOffset = new Vector3(0, 0, 1);

        // Instantiate the ally at the spawn point
        Instantiate(objectToSpawn, transform.position + spawnOffset, Quaternion.identity);
    }

    public void SetHealthUI(GameObject ui, Image image, TextMeshProUGUI text)
    {
        // Turn on the UI
        ui.SetActive(true);

        // Set Necromancer variables to the ones passed in
        necromancerUI = ui;
        necromancerHealthBar = image;
        necromancerHealthText = text;
    }
}
