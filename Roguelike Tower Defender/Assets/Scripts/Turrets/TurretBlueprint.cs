using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    [Header("Prefabs")]
    public GameObject levelOnePrefab;
    public GameObject levelTwoPrefab;
    public GameObject levelThreePrefab;

    [Header("Costs")]
    public int cost;
    public int upgradeOneCost;
    public int upgradeTwoCost;

    [Header("Other")]
    public Vector3 positionOffset;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
