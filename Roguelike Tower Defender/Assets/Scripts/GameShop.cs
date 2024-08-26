using UnityEngine;

public class GameShop : MonoBehaviour
{
    public TurretBlueprint testTurret;
    public TurretBlueprint anotherTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTestTurret()
    {
        buildManager.SelectTurretToBuild(testTurret);
    }

    public void SelectAnotherTurret()
    {
        buildManager.SelectTurretToBuild(anotherTurret);
    }
}
