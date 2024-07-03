using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer rend;

    private Color startColor;
    public Color hoverColor;

    void Start()
    {
        rend = GetComponent<Renderer>();

        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        if (gameObject.layer != 6 && MapGenerator.loaded)
        {
            rend.material.color = hoverColor;
        } 
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
