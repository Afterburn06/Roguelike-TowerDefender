using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager buildManager;

    [HideInInspector]
    public GameObject turret;

    [Header("Appearance")]
    public Renderer rend;
    private Color startColour;
    public Color hoverColour;

    void Start()
    {
        // Get the renderer of this node
        rend = this.GetComponent<Renderer>();

        // Set the starting colour
        startColour = rend.material.color;

        // Set the buildManager variable to the one in this scene
        buildManager = BuildManager.instance;
    }

    // When the mouse is clicked on this node
    void OnMouseDown()
    {
        // If the node clicked is a path tile
        if (gameObject.layer == 6)
        {
            // Don't execute further code
            return;
        }

        // If there is a turret on this node already and the game is not paused
        if (turret != null && !GameManager.gamePaused)
        {
            // Select this node
            buildManager.SelectNode(this);
            // Don't execute further code
            return;
        }

        // If the player is not allowed to build a turret or the mouse is over another object
        if (!buildManager.CanBuild || EventSystem.current.IsPointerOverGameObject())
        {
            // Don't execute further code
            return;
        }

        // Build a turret on this node
        buildManager.BuildTurretOn(this);
    }

    // When the mouse hovers over this node
    void OnMouseEnter()
    {
        // If the mouse is over another object or the game is over
        if (EventSystem.current.IsPointerOverGameObject() || GameManager.gameOver)
        {
            // Don't execute further code
            return;
        }

        // If not a path tile
        if (gameObject.layer != 6)
        {
            // Set the colour of the node to the hover colour
            rend.material.color = hoverColour;
        } 
    }

    // When the mouse leaves this node
    private void OnMouseExit()
    {
        // Reset the colour of the node
        rend.material.color = startColour;
    }
}
