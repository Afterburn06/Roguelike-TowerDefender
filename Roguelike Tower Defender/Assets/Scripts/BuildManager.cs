using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBlueprint turretToBuild;
    public GameObject testTurretPrefab;

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

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (MoneyManager.currentMoney < turretToBuild.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        if (UnitManager.currentUnits == UnitManager.maxUnits)
        {
            Debug.Log("Unit allowance reached.");
            return;
        }

        MoneyManager.currentMoney -= turretToBuild.cost;
        UnitManager.currentUnits++;

        GameObject turret = (GameObject)Instantiate(turretToBuild.levelOnePrefab, node.transform.position + turretToBuild.positionOffset, Quaternion.identity);
        node.turret = turret;
    }
}
