using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private Turret turretToBuild;

    [Header("Node UI")]
    public NodeUI nodeUI;

    [HideInInspector]
    public Node selectedNode;

    void Awake()
    {
        // If there is already a build manager
        if (instance != null)
        {
            // Throw error message
            Debug.LogError("More than one BuildManager in scene.");
            return;
        }

        // Set the scene's buildmanager to this one
        instance = this;
    }

    // Method that checks if a turret can be built
    public bool CanBuild { get { return turretToBuild != null; } }

    public void SelectTurretToBuild(Turret turret)
    {
        // Set's the BuildManager turret to the one passed in when the method is called
        turretToBuild = turret;
        // Deselects the node
        DeselectNode();
    }

    public void BuildTurretOn(Node node)
    {
        // If the player does not have enough money to build the turret
        if (MoneyManager.currentMoney < turretToBuild.baseCost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        // If the player already has the max number of units
        if (TurretManager.currentUnits == TurretManager.maxUnits)
        {
            Debug.Log("Unit allowance reached.");
            return;
        }

        // Reduce the player's money by the turret's build cost
        MoneyManager.currentMoney -= turretToBuild.baseCost;
        // Add a unit to the counter
        TurretManager.currentUnits++;

        // Spawn the turret at the selected node's position
        GameObject turret = (GameObject)Instantiate(turretToBuild.levelOnePrefab, node.transform.position + turretToBuild.positionOffset, Quaternion.identity);
        // Get the placed turret's script
        Turret script = turret.GetComponent<Turret>();
        
        // Set the turret's level to 1
        script.level = 1;
        // Set the node's turret to the one that was placed
        node.turret = turret;
    }

    public void SelectNode(Node node)
    {
        // Set the selected node to the one passed in when the method was called
        selectedNode = node;
        // Remove the previously selected turret
        turretToBuild = null;

        // Set the target node as this one
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        // Remove the previously selected node
        selectedNode = null;
    }
}
