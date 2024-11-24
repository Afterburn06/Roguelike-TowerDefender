using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public static bool setupComplete;

    [HideInInspector]
    public float currentCountdown;

    [Header("Setup Time")]
    public int setupTime;

    [Header("UI Elements")]
    public TextMeshProUGUI countdownText;
    public GameObject nextWaveButton;
    
    private EnemySpawner spawner;

    void Start()
    {
        // Get the enemy spawner
        spawner = GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>();

        // Reset the setup variable
        setupComplete = false;
        // Sets the countdown to the amount of time allowed to set up turrets
        currentCountdown = setupTime;
    }

    void Update()
    {
        // Don't do anything if the game is over
        if (GameManager.gameOver)
        {
            return;
        }

        // Reduce the countdown by one every second
        currentCountdown -= Time.deltaTime;
        // Don't let the countdown go below zero
        currentCountdown = Mathf.Clamp(currentCountdown, 0f, Mathf.Infinity);

        // Set the countdown text
        countdownText.text = string.Format("{0:0}", currentCountdown);

        // If the setup time isn't over and the countdown reacahes zero
        if (!setupComplete && currentCountdown == 0)
        {
            // Setup time is over
            setupComplete = true;
        }

        // Setup is over and the countdown is a third of the total countdown for this wave and it's not the final wave
        if (setupComplete && currentCountdown < spawner.waveCountdown * 2/3 && spawner.waveIndex != spawner.waves.Length && NextWaveButtonUI.canSkip)
        {
            // Show skip wave UI
            nextWaveButton.SetActive(true);
        }
        else
        {
            // Hide skip wave UI
            nextWaveButton.SetActive(false);
        }
    }
}
