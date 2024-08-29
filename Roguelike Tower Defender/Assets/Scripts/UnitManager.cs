using TMPro;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static int currentUnits;
    public static int maxUnits;

    public int maxUnitsValue;

    public TextMeshProUGUI unitText;

    void Start()
    {
        currentUnits = 0;

        maxUnits = maxUnitsValue;
    }

    void Update()
    {
        unitText.text = currentUnits.ToString() + " / " + maxUnits.ToString();
    }
}
