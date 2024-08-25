using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [HideInInspector]
    public GameObject turret;

    public Vector3 positionOffset;

    BuildManager buildManager;

    private Renderer rend;

    private Color startColor;
    public Color hoverColor;

    void Start()
    {
        rend = GetComponent<Renderer>();

        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }    

        if (turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject() || GameManager.gameOver || !MapGenerator.loaded || !buildManager.CanBuild)
        {
            return;
        }

        // If not a path tile
        if (gameObject.layer != 6 && MapGenerator.loaded)
        {
            rend.material.color = hoverColor;
        } 
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

}
