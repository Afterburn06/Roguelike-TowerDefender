using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    //[HideInInspector]
    public GameObject turret;

    public Vector3 positionOffset;

    BuildManager buildManager;

    public Renderer rend;

    public Color startColor;
    public Color hoverColor;

    void Start()
    {
        rend = this.GetComponent<Renderer>();

        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (turret != null || gameObject.layer == 6)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild || EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        buildManager.BuildTurretOn(this);
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
