using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public int cost;
    
    public GameObject basePrefab;
    public GameObject levelTwoPrefab;
    public GameObject levelThreePrefab;
    
    public int upgradeOneCost;
    public int upgradeTwoCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
