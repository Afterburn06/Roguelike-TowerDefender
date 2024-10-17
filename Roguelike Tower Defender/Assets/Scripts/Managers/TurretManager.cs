using TMPro;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public static int currentUnits;
    public static int maxUnits;

    // Same as maxUnits but accessable in inspector
    [Header("Unit Allowance")]
    public int maxUnitsValue;

    [Header("UI Elements")]
    public TextMeshProUGUI unitText;

    void Start()
    {
        // Reset currentUnits count
        currentUnits = 0;
        // Set the maxUnits variable to the one in the inspector
        maxUnits = maxUnitsValue;
    }

    void Update()
    {
        // Set the text displaying the amount of units to the number of current units out of the max units
        unitText.text = currentUnits.ToString() + " / " + maxUnits.ToString();
    }
}
