using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    [Header("Prefabs")]
    public GameObject levelOnePrefab;
    public GameObject levelTwoPrefab;
    public GameObject levelThreePrefab;

    [Header("Costs")]
    public int baseCost;
    public int upgradeOneCost;
    public int upgradeTwoCost;

    public int GetSellAmount()
    {
        return baseCost / 2;
    }
}
