using TMPro;
using UnityEngine;

public class EquippedTurretButton : MonoBehaviour
{
    [Header("Equipped Turret")]
    public GameObject myTurret;
    
    [Header("UI Elements")]
    public TextMeshProUGUI myText;

    void Update()
    {
        // If there is a unit assigned to the button
        if (myTurret != null)
        {
            // Set the button text to the unit name
            myText.text = myTurret.name;
        }
        else
        {
            // Make the button text blank
            myText.text = "";
        }
    }
}
