using UnityEngine;

public class GameShop : MonoBehaviour
{
    public TurretBlueprint testTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTestTurret()
    {
        buildManager.SelectTurretToBuild(testTurret);
    }
}
