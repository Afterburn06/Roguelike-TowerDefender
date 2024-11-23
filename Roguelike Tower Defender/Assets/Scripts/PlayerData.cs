using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int basicTier;
    public int sniperTier;
    public int sluggerTier;
    public int spitterTier;
    public int farmTier;
    public int materialOneAmount;
    public int materialTwoAmount;
    public bool sluggerUnlocked;
    public bool spitterUnlocked;
    public bool farmUnlocked;
    public int equippedTurretOne;
    public int equippedTurretTwo;
    public int equippedTurretThree;
    public int equippedTurretFour;
    public int equippedTurretFive;

    public PlayerData (PlayerStats playerStats)
    {
        basicTier = PlayerStats.basicTier;
        sniperTier = PlayerStats.sniperTier;
        sluggerTier = PlayerStats.sluggerTier;
        spitterTier = PlayerStats.spitterTier;
        farmTier = PlayerStats.farmTier;

        materialOneAmount = PlayerStats.materialOneAmount;
        materialTwoAmount = PlayerStats.materialTwoAmount;

        equippedTurretOne = PlayerStats.equippedTurretOne;
        equippedTurretTwo = PlayerStats.equippedTurretTwo;
        equippedTurretThree = PlayerStats.equippedTurretThree;
        equippedTurretFour = PlayerStats.equippedTurretFour;
        equippedTurretFive = PlayerStats.equippedTurretFive;

        sluggerUnlocked = PlayerStats.sluggerUnlocked;
        spitterUnlocked = PlayerStats.spitterUnlocked;
        farmUnlocked = PlayerStats.farmUnlocked;
    }
}
