using TMPro;
using UnityEngine;

public class CurrentUnitButton : MonoBehaviour
{
    public GameObject myUnit;
    public TextMeshProUGUI myText;

    void Update()
    {
        if (myUnit != null)
        {
            myText.text = myUnit.name;
        }
        else
        {
            myText.text = "";
        }
    }
}
