using UnityEngine;
using UnityEngine.EventSystems;

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
        if (EventSystem.current.IsPointerOverGameObject() || GameManager.gameOver || !MapGenerator.loaded)
        {
            return;
        }

        // If not a path tile
        if (gameObject.layer != 6)
        {
            rend.material.color = hoverColor;
        } 
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
