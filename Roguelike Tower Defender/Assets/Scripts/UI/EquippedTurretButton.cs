using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquippedTurretButton : MonoBehaviour
{
    [Header("Equipped Turret")]
    public GameObject myTurret;
    
    [Header("UI Elements")]
    public TextMeshProUGUI myText;
    public Image myImage;

    void Update()
    {
        // If there is a unit assigned to the button
        if (myTurret != null)
        {
            // Set the button text to the unit name
            myText.text = myTurret.name;
            myImage.sprite = myTurret.GetComponent<Turret>().turretSprite;

            // Make the image opaque
            Color newColor = myImage.color;
            newColor.a = 1;
            myImage.color = newColor;
        }
        else
        {
            // Make the button text blank
            myText.text = "";

            // Make the image transparent
            Color newColor = myImage.color;
            newColor.a = 0;
            myImage.color = newColor;
        }
    }
}
