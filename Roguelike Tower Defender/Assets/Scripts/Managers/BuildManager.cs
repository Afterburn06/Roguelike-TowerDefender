using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private Turret turretToBuild;

    public Node selectedNode;
    public NodeUI nodeUI;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene.");
            return;
        }

        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null; } }

    public void SelectTurretToBuild(Turret turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void BuildTurretOn(Node node)
    {
        if (MoneyManager.currentMoney < turretToBuild.baseCost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        if (UnitManager.currentUnits == UnitManager.maxUnits)
        {
            Debug.Log("Unit allowance reached.");
            return;
        }

        MoneyManager.currentMoney -= turretToBuild.baseCost;
        UnitManager.currentUnits++;

        GameObject turret = (GameObject)Instantiate(turretToBuild.levelOnePrefab, node.transform.position + turretToBuild.positionOffset, Quaternion.identity);
        Turret script = turret.GetComponent<Turret>();
        
        script.level = 1;
        node.turret = turret;
    }

    public void SelectNode(Node node)
    {
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
    }
}
